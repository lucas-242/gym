namespace Gym.Entities
{
    public partial class Tip
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; } = null!;
    }
}
