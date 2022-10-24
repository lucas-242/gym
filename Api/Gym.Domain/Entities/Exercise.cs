namespace Gym.Entities
{
    public partial class Exercise : BaseEntity
    {
        public string Name { get; set; } = null!;

        public virtual ICollection<Execution>? Executions { get; set; }
        public virtual ICollection<ExerciseImage>? ExerciseImages { get; set; }
        public virtual ICollection<ExerciseMuscle> ExerciseMuscles { get; set; } = null!;
        public virtual ICollection<Tip>? Tips { get; set; }
        public virtual ICollection<WorkoutExercise>? WorkoutExercises { get; set; }
    }
}
