using Gym.Workout.Enums;

namespace Gym.Workout.Interfaces
{
    internal interface IWorkout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IExerciseFromWorkout> Exercises { get; set; }
        public IEnumerable<Day> DaysToBeExecuted { get; set; }
    }
}
