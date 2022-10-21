namespace Gym.Entities
{
    public partial class Company
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Cnpj { get; set; } = null!;
        public string? Image { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? IsActive { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual ICollection<BusinessHour>? BusinessHours { get; set; }
        public virtual ICollection<Routine>? Routines { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
