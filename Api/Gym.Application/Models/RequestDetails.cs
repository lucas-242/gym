using Gym.Enums;

namespace Gym.Application.Models
{
    public class RequestDetails
    {
        public string Ip { get; set; }
        public int? UserId { get; set; }
        public Role? UserRole { get; set; }
        public bool ThereIsUser { get => UserId != null; }

        public RequestDetails(string ip, int? userId = null, Role? userRole = null) 
        {
            Ip = ip;
            UserId = userId;
            UserRole = userRole;
        }
    }
}
