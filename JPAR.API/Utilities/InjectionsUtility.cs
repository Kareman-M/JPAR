using JPAR.Infrastructure.Context;
using JPAR.Infrastructure.IRepository;
using JPAR.Infrastructure.Repository;
using JPAR.Service.IServices;
using JPAR.Service.IServices.IAuthentication;
using JPAR.Service.Models;
using JPAR.Service.Services;
using JPAR.Service.Services.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JPAR.API.Utilities
{
    public static class InjectionsUtility
    {

        internal static IServiceCollection AddInjectUtility(this IServiceCollection services)
        => services.InjectServices().InjectReposytories().InjectUserIdentity().AddSecurityUtility();

        private static IServiceCollection InjectReposytories(this IServiceCollection services)
        {
            services
                .AddScoped<IApplicantRepository, ApplicantRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IRecruiterRepository,RecruiterRepository>()
                .AddScoped<IJobPostRepository, JobPostRepository>();
            return services;
        }

        private static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services
                .AddScoped<IApplicantService, ApplicantService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IJobPostService, JobPostService>()
                .AddScoped<IAuthenticatorService, AuthenticatorService>()
                .AddScoped<IAccessTokenGeneratorService, AccessTokenGeneratorService>()
                .AddScoped<IRefreshTokenGeneratorService, RefreshTokenGeneratorService>()
                .AddScoped<ITokenGeneratorService, TokenGeneratorService>();
            return services;
        }

        private static IServiceCollection InjectUserIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User = UserOptions;
                options.Password = PasswordOptions;
                options.Lockout = LockoutOptions();
            })
             .AddEntityFrameworkStores<ApplicationDBContext>()
             .AddDefaultTokenProviders()
            .AddSignInManager<SignInManager<User>>();

            return services;
        }

        public static IServiceCollection AddSecurityUtility(this IServiceCollection services)
        {
            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                    opt.TokenLifespan = TimeSpan.FromHours(1)
                    );
            var jwtConfigurationModel = new JwtConfigurationModel
            {
                AccessTokenSecret = "7sZgtVhkB4s0MkATFK-MNT0w3uN3VBTuzXBX9JJPgCb7QjWqxlnYbK-QfftwUGU2P2MFv5pHJuxsrgmaXDbMMV25SjkUSg_jUWNI_qcVJTA3us9jD1hzGY63cSHIaIghGmi8y9xvHfhqMk9xqJmiHGQXdNa3vUfM4M82TNNxlo0",
                RefreshTokenSecret = "2lA6QaS0EMW6e59FBBCmyKbs2WewBhBYofO5QXxGSE-Ipl7yY2KF6-x149EIAGYIM8beU0LbnlltuvHJOe9FAr4Z00QL2zaGE1HY0Vpucs56ooQn4Fcsg07wGWmO7hJdXcf3fvOuBdgx7n9vTh1LXPRadURFPHs1EwufHyXDs8M",
                AccessTokenExpirationDurationMinutes = 3679200, //"2000000",
                RefreshTokenExpirationDurationMinutes = 10000,
                Issuer = "https://localhost:7213/",
                Audience = "https://localhost:7213/"
            };

            services.AddSingleton(jwtConfigurationModel);
            services.AddAuthenticationExtenssion(jwtConfigurationModel);
            return services;
        }

        public static IServiceCollection AddAuthenticationExtenssion(this IServiceCollection services, JwtConfigurationModel jwtConfiguration)
        {
            services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.AccessTokenSecret)),
                        ValidIssuer = jwtConfiguration.Issuer,
                        ValidAudience = jwtConfiguration.Audience,
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            return services;
        }

        #region Private

        /// <summary>
        /// Gets User Options
        /// </summary>
        private static UserOptions UserOptions => new()
        {
            RequireUniqueEmail = true,
        };

        /// <summary>
        /// Gets Password Options
        /// </summary>
        private static PasswordOptions PasswordOptions => new()
        {
            RequireDigit = false,
            RequireNonAlphanumeric = false,
            RequireUppercase = false,
            RequiredLength = 6
        };

        /// <summary>
        /// Gets Lockout Options
        /// </summary>
        /// <param name="configuration"> configuration </param>
        /// <returns> Lockout Options </returns>
        private static LockoutOptions LockoutOptions() => new()
        {
            AllowedForNewUsers = true,
            DefaultLockoutTimeSpan = TimeSpan.Zero,
            MaxFailedAccessAttempts = 4
        };

        #endregion
    }
}
