using Gym.DataAccess.Request;
using Gym.Entities;

namespace Gym.Services
{
    public interface IRoutineService
    {
        public Routine? Get(int id);
        public void Delete(int id);
        public Routine CreateOrUpdate(int id, RoutineRequest routine);
    }
}
