using System;
using System.Collections.Generic;

namespace Gym.Domain.Entities
{
    public partial class Muscle
    {
        public Muscle()
        {
            ExerciseMuscles = new HashSet<ExerciseMuscle>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ExerciseMuscle> ExerciseMuscles { get; set; }
    }
}
