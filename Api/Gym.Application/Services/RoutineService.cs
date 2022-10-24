using Gym.Application.Repositories;
using Gym.DataAccess.Request;
using Gym.Entities;
using Gym.Exceptions;
using Gym.Services;
using System.Net;

namespace Gym.Application.Services
{
    internal class RoutineService : IRoutineService
    {
        private readonly IRoutineRepository _routineRepository;

        public RoutineService(IRoutineRepository routineRepository)
        {
            _routineRepository = routineRepository;
        }


        public Routine CreateOrUpdate(int id, RoutineRequest model)
        {
            Routine result;
            var routineFound = _routineRepository.Get(id);
            if (routineFound is null)
            {
                result = Create(model);
            }
            else
            {
                result = Update(id, model);
            }
            _routineRepository.SaveChanges();
            return result;
        }


        private Routine Create(RoutineRequest model)
        {
            model.UpdatedBy = model.CreatedBy;
            var result = _routineRepository.Create(model);
            return result;
        }


        private Routine Update(int id, RoutineRequest model)
        {
            if (model.UpdatedBy == null)
            {
                throw new AppException(HttpStatusCode.BadRequest, "UpdatedBy is mandatory");
            }

            Routine routine = model;
            routine.Id = id;

            var result = _routineRepository.Update(routine);
            return result;
        }

        public Routine? Get(int id)
        {
            var result = _routineRepository.Get(id);
            return result;
        }

        public void Delete(int id)
        {
            var routine = _routineRepository.Get(id);
            if (routine is null)
            {
                throw new AppException(HttpStatusCode.NotFound, $"No Routine with the indentifier {id}");
            }

            _routineRepository.Delete(routine);
            _routineRepository.SaveChanges();
        }
    }
}
