namespace Gym.Workout.Interfaces
{
    internal interface IExercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<IMuscle> PrimaryMuscles { get; set; }
        public IEnumerable<IMuscle> SecondaryMuscles { get; set; }
        public string Preparation { get; set; }
        public IEnumerable<string> Execution { get; set; }
        public IEnumerable<string> Tips { get; set; }
    }
}
