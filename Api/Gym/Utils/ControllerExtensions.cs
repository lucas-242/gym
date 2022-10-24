using Gym.Exceptions;

namespace Gym.Api.Utils
{
    internal static class ControllerExtensions
    {
        public static string GetIpAddress(this HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
                return context.Request.Headers["X-Forwarded-For"];

            if (context.Connection.RemoteIpAddress == null)
                throw new AppException(System.Net.HttpStatusCode.InternalServerError, "Error to found the requester address");

            return context.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
