using WebAppBB.Repositories;
using WebAppBB.Services;

namespace WebAppBB.Configure
{
    public static class ConfigCategories
    {
        private static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<CategoriesRepository, CategoriesRepository>();
        }
        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient(s =>
            {
                CategoriesService service = new CategoriesService(
                    s.GetRequiredService<CategoriesRepository>()
                    );
                return service;
            });
        }

        public static void AddCategories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository();
            services.AddServices();
        }
    }
}
