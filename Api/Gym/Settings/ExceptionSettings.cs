using Gym.Api.Exceptions;

namespace Gym.Api.Settings
{
    public static class ExceptionSettings
    {
        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
