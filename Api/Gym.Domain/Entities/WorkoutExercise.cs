namespace Gym.Entities
{
    public partial class WorkoutExercise : BaseEntity
    {
        public int Id { get; set; }
        public string? Comments { get; set; }
        public int RestBetweenSets { get; set; }
        public string? MachineNumber { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; } = null!;
        public virtual Workout Workout { get; set; } = null!;
        public virtual ICollection<Set> Sets { get; set; } = null!;
    }
}
