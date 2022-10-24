using Gym.Application.Persistence;
using Gym.Application.Repositories;
using Gym.Application.Services.Repositories;
using Gym.EntityFramework.Persistence;
using Gym.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gym.EntityFramework
{
    public static class DependencyInjector
    {
        public static void InjectDatabase(this IServiceCollection services,
          IConfiguration configuration)
        {
            InjectPersistence(services, configuration);
            InjectRepostories(services);
        }

        private static void InjectPersistence(this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }

        private static void InjectRepostories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IRoutineRepository, RoutineRepository>();
        }
    }
}
