using Gym.Entities;

namespace Gym.Application.Repositories
{
    public interface IRoutineRepository
    {
        public Routine? Get(int id);
        public Routine Create(Routine routine);
        public Routine Update(Routine routine);
        public void SaveChanges();
    }
}
