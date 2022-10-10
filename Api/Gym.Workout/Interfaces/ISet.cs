
namespace Gym.Workout.Interfaces
{
    internal interface ISet
    {
        public int Id { get; set; }
        public int? Repetitions { get; set; }
        public int? Load { get; set; }
        public int? Duration { get; set; }
    }
}
