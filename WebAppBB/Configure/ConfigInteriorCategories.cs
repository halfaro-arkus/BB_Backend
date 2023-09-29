using WebAppBB.Repositories;
using WebAppBB.Services;

namespace WebAppBB.Configure
{
    public static class ConfigInteriorCategories
    {
        private static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<InteriorCategoriesRepository, InteriorCategoriesRepository>();
        }
        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient(s =>
            {
                InteriorCategoriesService service = new InteriorCategoriesService(
                    s.GetRequiredService<InteriorCategoriesRepository>()
                    );
                return service;
            });
        }

        public static void AddInteriorCategories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository();
            services.AddServices();
        }
    }
}
