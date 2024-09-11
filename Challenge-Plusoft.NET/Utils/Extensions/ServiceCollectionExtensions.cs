using Microsoft.Extensions.DependencyInjection;
using PlusoftRecommender.Repositories;
using PlusoftRecommender.Services;
using PlusoftRecommender.Utils;

namespace PlusoftRecommender.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // Registrando o ConfigManager como singleton
            services.AddSingleton<ConfigManager>();

            // Registrando repositórios
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRecommendationRepository, RecommendationRepository>();

            // Registrando serviços
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRecommendationService, RecommendationService>();

            return services;
        }
    }
}
