namespace Gym.Entities
{
    public partial class Address
    {
        public Address()
        {
            Companies = new HashSet<Company>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Neighborhood { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int Number { get; set; }
        public string? Complement { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
