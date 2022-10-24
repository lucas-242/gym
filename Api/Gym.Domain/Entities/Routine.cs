using Gym.DataAccess.Request;

namespace Gym.Entities
{
    public partial class Routine : BaseEntity
    {
        public string Name { get; set; } = null!;
        public DateTime? ExpirationDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int? StudentId { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual User? Student { get; set; }
        public virtual User UpdatedByNavigation { get; set; } = null!;
        public virtual ICollection<Workout> Workouts { get; set; } = null!;


        public static implicit operator Routine(RoutineRequest routineRequest) => new()
        {
            Name = routineRequest.Name,
            ExpirationDate = routineRequest.ExpirationDate,
            CreatedBy = routineRequest.CreatedBy,
            UpdatedBy = (int)routineRequest.UpdatedBy,
            StudentId = routineRequest.StudentId,
            CompanyId = routineRequest.CompanyId,
        };
    }
}
