
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAppBB.Configure;
using WebAppBB.Models;

namespace WebAppBB

{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            string connectionStr = Configuration.GetConnectionString("MyDatabase");
            services.AddDbContextPool<BbContext>(options => options.UseSqlServer(connectionStr));            
            services.AddBbPublicCors();
            services.AddBbConfigure(Configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BB", Version = "v1" });

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BbContext>();
                if (context != null && context.Database != null)
                {
                    //context.Database.Migrate();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WAIA v1"));
            }
            app.UseCors(ConfigureCors.CorsPolicyName);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();

            });

        }
    }
}
