namespace Gym.Entities
{
    public partial class Muscle : BaseEntity
    {
        public string Name { get; set; } = null!;

        public virtual ICollection<ExerciseMuscle>? ExerciseMuscles { get; set; }
    }
}
