﻿namespace Gym.Entities
{
    public partial class ExerciseMuscle
    {
        public int Id { get; set; }
        public bool IsPrimary { get; set; }
        public int ExerciseId { get; set; }
        public int MuscleId { get; set; }

        public virtual Exercise Exercise { get; set; } = null!;
        public virtual Muscle Muscle { get; set; } = null!;
    }
}
