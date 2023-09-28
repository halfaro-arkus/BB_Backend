namespace WebAppBB.Configure
{
    public static class ConfigureCors
    {
        public const string CorsPolicyName = "bb";
        public static void AddBbPublicCors(this IServiceCollection services) => services
            .AddCors(o => o.AddPolicy(CorsPolicyName, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
    }
}
