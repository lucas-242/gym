﻿namespace Gym.Entities
{
    public partial class User : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int? CompanyId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }
        public virtual ICollection<Routine>? RoutineCreatedByNavigations { get; set; }
        public virtual ICollection<Routine>? RoutineStudents { get; set; }
        public virtual ICollection<Routine>? RoutineUpdatedByNavigations { get; set; }
    }
}
