namespace Gym.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; } = null!;
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime CreatedAt { get; set; }
        public string CreatedByIp { get; set; } = null!;
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; } = null!;
        public string ReplacedByToken { get; set; } = null!;
        public bool IsActive => Revoked == null && !IsExpired;
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;

    }
}
