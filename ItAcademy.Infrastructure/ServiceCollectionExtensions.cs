

using ItAcademy.DataAccess;
using ItAcademy.DataAccess.CQS.Commands.Articles;
using ItAcademy.DataAccess.Repositories;
using ItAcademy.Database.Entities;
using ItAcademy.Services;
using ItAcademy.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ItAcademy.Infrastructure
{
    //generate IServiceCollection extension method with "RegisterArticleAggregator" method
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection RegisterArticleAggregatorUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IRepository<Source>, SourceRepository>();
            services.AddScoped<IRepository<Role>, Repository<Role>>();
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            return services;
        }
        
        public static IServiceCollection RegisterArticleAggregatorServices(this IServiceCollection services)
        {
           services.AddScoped<IArticleService, ArticleService>();
           services.AddScoped<IUserService, UserService>(); 
           services.AddScoped<IRoleService, RoleService>(); 
           services.AddScoped<ITokenService, TokenService>(); 
            
            return services;
        }

        public static IServiceCollection RegisterArticleAggregatorMediatr(this IServiceCollection services)
        {
           services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(InsertUniqueArticlesFromRssDataCommand).Assembly);
            });

            return services;
        }
    }
}
