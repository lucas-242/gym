namespace Gym.Entities
{
    public partial class Workout
    {
        public Workout()
        {
            WorkoutExercises = new HashSet<WorkoutExercise>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public int RoutineId { get; set; }

        public virtual Routine Routine { get; set; } = null!;
        public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
