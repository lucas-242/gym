using Gym.Application.Models;
using Gym.Enums;
using Gym.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Gym.Application.Utils
{
    internal static class HttpContextAccessorExtensions
    {
        public static RequestDetails GetRequestDetails(this IHttpContextAccessor context)
        {
            var result = new RequestDetails(context.HttpContext!.GetIpAddress(), context.HttpContext!.GetId(), context.HttpContext!.GetRole());
            return result;
        }

        private static string GetIpAddress(this HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
                return context.Request.Headers["X-Forwarded-For"];

            if (context.Connection.RemoteIpAddress == null)
                throw new AppException(System.Net.HttpStatusCode.InternalServerError, "Error to found the requester address");

            return context.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        private static int? GetId(this HttpContext context)
        {
            var claimIdentifier = context.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (claimIdentifier is not null)
            {
                _ = int.TryParse(claimIdentifier.Value, out int result);
                return result;
            }

            return null;
        }

        private static Role? GetRole(this HttpContext context)
        {
            var claimRole = context.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Role);
            if (claimRole is not null)
            {
                _ = Enum.TryParse(claimRole.Value, out Role result);
                return result;
            }

            return null;
        }
    }
}
