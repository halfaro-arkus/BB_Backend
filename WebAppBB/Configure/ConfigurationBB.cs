using Microsoft.Extensions.DependencyInjection;
using WebAppBB.Configure;

namespace WebAppBB.Configure
{
    public static class ConfigurationBB
    {
        public static void AddBbConfigure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddContent(configuration);            
        }
    }
}
