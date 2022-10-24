namespace Gym.Entities
{
    public partial class Set : BaseEntity
    {
        public int? Repetitions { get; set; }
        public int? Load { get; set; }
        public int? Duration { get; set; }
        public int WorkoutExerciseId { get; set; }

        public virtual WorkoutExercise WorkoutExercise { get; set; } = null!;
    }
}
