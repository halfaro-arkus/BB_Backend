using WebAppBB.Repositories;
using WebAppBB.Services;

namespace WebAppBB.Configure
{
    public static class ConfigSubCategories
    {
        private static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<SubCategoriesRepository , SubCategoriesRepository>();
        }
        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient(s =>
            {
                SubCategoriesService service = new SubCategoriesService(
                    s.GetRequiredService<SubCategoriesRepository>()
                    );
                return service;
            });
        }

        public static void AddSubCategories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository();
            services.AddServices();
        }
    }
}
