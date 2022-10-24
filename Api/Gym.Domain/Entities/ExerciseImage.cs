namespace Gym.Entities
{
    public partial class ExerciseImage : BaseEntity
    {
        public string Url { get; set; } = null!;
        public int ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; } = null!;
    }
}
