using Gym.Authentication.Domain.Services;
using Gym.Authentication.Repositories;
using Gym.Authentication.Services;
using Gym.Authentication.Services.Repositories;

namespace Gym.Settings
{
    internal static class DependencyInjector
    {
        public static void InjectDependencies(this IServiceCollection services)
        {
            InjectServices(services);
            InjectRepostories(services);
        }


        private static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPasswordHasherService, PasswordHasherService>();
        }

        private static void InjectRepostories(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
        }
    }
}
