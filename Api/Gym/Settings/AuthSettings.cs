using Gym.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Gym.Api.Settings
{
    internal static class AuthSettings
    {

        public static IServiceCollection AddPolicies(this IServiceCollection services, IConfiguration configuration)
        {

            var origins = configuration.GetSection("Origins").GetChildren().Select(x => x.Value).ToArray();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                             builder =>
                             {
                                 builder.WithOrigins(origins);
                                 builder.AllowAnyHeader();
                                 builder.AllowAnyMethod();
                                 builder.AllowCredentials();
                             }
                     );
            });


            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policy.NotStudent.ToString(),
                             policy =>
                             {
                                 policy.RequireRole(Role.admin.ToString(), Role.teacher.ToString());
                             }
                     );
            });

            return services;
        }

        public static IServiceCollection AddBearer(this IServiceCollection services, IConfiguration configuration)
        {

            var key = Encoding.ASCII.GetBytes(configuration.GetSection("AuthConfigs").GetSection("JwtSecret").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.FromSeconds(0),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
