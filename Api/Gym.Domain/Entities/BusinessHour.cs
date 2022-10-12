using System;
using System.Collections.Generic;

namespace Gym.Domain.Entities
{
    public partial class BusinessHour
    {
        public int Id { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
