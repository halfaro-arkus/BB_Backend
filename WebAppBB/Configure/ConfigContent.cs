using WebAppBB.Repositories;
using WebAppBB.Services;

namespace WebAppBB.Configure
{
    public static class ConfigContent
    {
        
        private static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ContentRepository, ContentRepository>();           
        }
        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient(s =>
            {
                ContentService ClientsService = new ContentService(
                    s.GetRequiredService<ContentRepository>()                    
                    );
                return ClientsService;
            });
        }

        public static void AddContent(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository();
            services.AddServices();            
        }
    }
}
