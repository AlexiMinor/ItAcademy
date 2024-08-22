
using System.Reflection;
using System.Text;
using ItAcademy.Database;
using ItAcademy.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ItAcademy.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1.0" });
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
                //options.AddSecurityDefinition("Bearer",
                //    new OpenApiSecurityScheme
                //    {
                //        Description =
                //            "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //        Name = "Authorization",
                //        In = ParameterLocation.Header,
                //        Type = SecuritySchemeType.ApiKey,
                //        Scheme = "Bearer"
                //    });
                //options.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                //        },
                //        new string[] { }
                //    }
                //});
            });

            builder.Services.AddDbContext<ArticleAggregatorContext>(
                opt => opt.UseSqlServer(
                    builder.Configuration.GetConnectionString("Default")));

            var jwtIss = builder.Configuration.GetSection("Jwt:Iss").Get<string>();
            var jwtAud = builder.Configuration.GetSection("Jwt:Aud").Get<string>();
            var jwtKey = builder.Configuration.GetSection("Jwt:Secret").Get<string>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    //opt.
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtIss,
                        ValidAudience = jwtAud,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtKey))
                    };
                });
            builder.Services.AddAuthorization();
            
            builder.Services.RegisterArticleAggregatorUnitOfWork();
            builder.Services.RegisterArticleAggregatorServices();
            builder.Services.RegisterArticleAggregatorMediatr();

            builder.Services.AddMemoryCache();
            //(options =>
            //{
            //    options.
            //    options.SizeLimit = 
            //});
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
