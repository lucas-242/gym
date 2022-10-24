namespace Gym.DataAccess.Request
{
    public class RoutineRequest
    {
        public string Name { get; set; } = null!;
        public DateTime? ExpirationDate { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? StudentId { get; set; }
        public int CompanyId { get; set; }
    }
}
