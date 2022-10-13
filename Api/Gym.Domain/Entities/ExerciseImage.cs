﻿namespace Gym.Entities
{
    public partial class ExerciseImage
    {
        public int Id { get; set; }
        public string Url { get; set; } = null!;
        public int ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; } = null!;
    }
}
