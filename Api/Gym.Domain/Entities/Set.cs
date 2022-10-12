using System;
using System.Collections.Generic;

namespace Gym.Domain.Entities
{
    public partial class Set
    {
        public int Id { get; set; }
        public int? Repetitions { get; set; }
        public int? Load { get; set; }
        public int? Duration { get; set; }
        public int WorkoutExerciseId { get; set; }

        public virtual WorkoutExercise WorkoutExercise { get; set; } = null!;
    }
}
