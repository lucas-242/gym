using Gym.DataAccess.Request;
using Gym.Entities;

namespace Gym.Services
{
    public interface IRoutineService
    {
        public Routine CreateOrUpdate(int id, RoutineRequest routine);
    }
}
