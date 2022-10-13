using Gym.Application.Services;
using Gym.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Gym.Application
{
    public static class DependencyInjector
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPasswordHasherService, PasswordHasherService>();
        }
    }
}
