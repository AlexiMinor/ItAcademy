using System.Collections;
using ItAcademy.DataAccess;
using ItAcademy.DataAccess.CQS.Commands.Articles;
using ItAcademy.DataAccess.CQS.Queries;
using ItAcademy.DataAccess.CQS.Queries.Articles;
using ItAcademy.DataAccess.Repositories;
using ItAcademy.Database;
using ItAcademy.Database.Entities;
using ItAcademy.DTOs;
using ItAcademy.MVC.Filters;
using ItAcademy.MVC.Middlewares;
using ItAcademy.MVC.Models;
using ItAcademy.Services;
using ItAcademy.Services.Abstractions;
using ItAcademy.Services.Abstractions.Test;
using ItAcademy.Services.Test;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

namespace ItAcademy.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("log.log")
                .CreateBootstrapLogger();

            var builder = WebApplication.CreateBuilder(args);

            //builder.Configuration.AddJsonFile("settings.json");
            var secrets = new Secrets();
            builder.Configuration.Bind("Secrets", secrets);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSerilog((services, lc) => lc
                .ReadFrom.Configuration(builder.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .WriteTo.Console(LogEventLevel.Error)
                .WriteTo.File("log.log"));

            builder.Services.AddSession();
            
            builder.Services.AddDbContext<ArticleAggregatorContext>(
                opt => opt.UseSqlServer(
                    builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
            builder.Services.AddScoped<IRepository<Source>, SourceRepository>();
            builder.Services.AddScoped<IRepository<Role>, Repository<Role>>();
            builder.Services.AddScoped<IRepository<User>, Repository<User>>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            builder.Services.AddScoped<IArticleService, ArticleService>();
            builder.Services.AddScoped<ITestService, TestService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof( InsertUniqueArticlesFromRssDataCommand).Assembly);
            });


            //builder.Services.AddSingleton<IUrlHelper, UrlHelper>();
            //builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            builder.Services.AddTransient<ITransientService, TransientService>();
            builder.Services.AddScoped<IScopedService, ScopedService>();
            builder.Services.AddSingleton<ISingletonService, SingletonService>();
            //builder.Services.AddScoped<TestResourceFilter>();

            //builder.Services.AddControllersWithViews(opt =>
            //{
            //    //opt.Filters.Add(typeof(TestResourceFilter));
            //    //opt.Filters.Add(new TestResourceFilter(12));
            //    //opt.Filters.Add<TestResourceFilter>();
            //});
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.LoginPath = "/user/login";
                });
            builder.Services.AddAuthorization();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseSerilogRequestLogging();
            
            app.UseAuthentication();
            app.UseAuthorization();
            //const string token = "123";
            ////app.UseMiddleware<QuerySecurityCheckMiddleware>(token);
            //app.UseQuerySecurity(token);
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "qa",
                pattern: "qa/{action=Index}/{controller=Home}/{id?}/{age?}");

            app.Map("/secret-page", () => secrets);

            app.Map("sitemap.xml", (IEnumerable<EndpointDataSource> data) =>
            {
                var endpoints = data.SelectMany(source => source.Endpoints);
                return string.Join(Environment.NewLine, endpoints);
            });

            app.Run();
        }
    }
}
