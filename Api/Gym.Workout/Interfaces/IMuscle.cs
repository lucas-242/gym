namespace Gym.Workout.Interfaces
{
    internal interface IMuscle
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public bool IsFrontal { get; set; }
    }
}
