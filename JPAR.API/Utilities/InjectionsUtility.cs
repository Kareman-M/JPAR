using JPAR.Infrastructure.Context;
using JPAR.Infrastructure.IRepository;
using JPAR.Infrastructure.Repository;
using JPAR.Service.IServices;
using JPAR.Service.Services;

namespace JPAR.API.Utilities
{
    public static class InjectionsUtility
    {

        internal static IServiceCollection AddInjectUtility(this IServiceCollection services)
        => services.InjectReposytories()
            .InjectServices();


        private static IServiceCollection InjectReposytories(this IServiceCollection services)
           => services.AddScoped<IApplicantRepository, ApplicantRepository>();

        private static IServiceCollection InjectServices(this IServiceCollection services)
            => services.AddScoped<IApplicantService, ApplicantService>();
    }
}
