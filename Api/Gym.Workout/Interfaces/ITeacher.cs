using Gym.Authentication.Domain.Interfaces;

namespace Gym.Workout.Interfaces
{
    internal interface ITeacher : IUser
    {
        public int Registration { get; set; }
        //public int Shift { get; set; }
        public DateTime HiredAt { get; set; }
    }
}
