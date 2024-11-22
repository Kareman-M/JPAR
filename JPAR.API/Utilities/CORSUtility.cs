namespace JPAR.API.Utilities
{
    public static class CORSUtility
    {
        internal static IServiceCollection AddCorsUtility(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedHosts = configuration.GetSection("AllowedHosts").Get<string[]>();
            services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicyName", policy =>
                {
                    policy.WithOrigins(allowedHosts)
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials();
                });
            });
            return services;
        }
    }
}
