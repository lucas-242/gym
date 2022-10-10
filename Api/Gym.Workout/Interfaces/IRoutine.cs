namespace Gym.Workout.Interfaces
{
    internal interface IRoutine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IWorkout> Workouts { get; set; }
        public ITeacher CreatedBy { get; set; }
        public ITeacher? UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
