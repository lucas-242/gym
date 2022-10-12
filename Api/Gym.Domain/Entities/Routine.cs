using System;
using System.Collections.Generic;

namespace Gym.Domain.Entities
{
    public partial class Routine
    {
        public Routine()
        {
            Workouts = new HashSet<Workout>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? ExpirationDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int? StudentId { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual User? Student { get; set; }
        public virtual User UpdatedByNavigation { get; set; } = null!;
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
