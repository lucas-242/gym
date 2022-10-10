namespace Gym.Workout.Interfaces
{
    internal interface IExerciseFromWorkout
    {
        public int Id { get; set; }
        public IExercise Exercise { get; set; }
        public IEnumerable<ISet> Sets { get; set; }
        public int RestBetweenSets { get; set; }
        public int? MachineNumber { get; set; }
        public string Comments { get; set; }
    }
}
