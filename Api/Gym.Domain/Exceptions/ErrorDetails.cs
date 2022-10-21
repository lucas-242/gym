using System.Net;
using System.Text.Json;

namespace Gym.Exceptions
{
    public class ErrorDetails
    {
        public string Message { get; set; } = null!;
        public string? Details { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
