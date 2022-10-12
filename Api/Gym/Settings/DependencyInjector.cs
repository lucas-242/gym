using Gym.Application.Repositories;
using Gym.Application.Services;
using Gym.Application.Services.Repositories;
using Gym.Domain.Services;
using Gym.Infrastructure.Repositories;

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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPasswordHasherService, PasswordHasherService>();
        }

        private static void InjectRepostories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
        }
    }
}
