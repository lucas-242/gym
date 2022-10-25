using Gym.Application.Models;
using Gym.Application.Repositories;
using Gym.Application.Utils;
using Gym.DataAccess.Request;
using Gym.Entities;
using Gym.Enums;
using Gym.Exceptions;
using Gym.Services;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Gym.Application.Services
{
    internal class RoutineService : IRoutineService
    {
        private readonly IRoutineRepository _routineRepository;
        private readonly RequestDetails _requestDetails;

        public RoutineService(IRoutineRepository routineRepository, IHttpContextAccessor httpContextAccessor)
        {
            _routineRepository = routineRepository;
            _requestDetails = httpContextAccessor.GetRequestDetails();
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
        public IEnumerable<Routine> GetByStudent(int studentId)
        {
            var result = _routineRepository.GetByStudent(studentId);
            CheckUserAccessToResources(result);
            return result;
        }

        public Routine? Get(int id)
        {
            var result = _routineRepository.Get(id);
            CheckUserAccessToResource(result);
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

        private void CheckUserAccessToResources(IEnumerable<Routine> routines)
        {
            if (_requestDetails.UserRole == Role.student && routines.Any(r => r.StudentId != _requestDetails.UserId))
            {
                throw new AppException(HttpStatusCode.Forbidden, "User doesn't have access to the requested routine");
            }
        }

        private void CheckUserAccessToResource(Routine? routine)
        {
            if (routine is not null && _requestDetails.UserRole == Role.student && routine.StudentId != _requestDetails.UserId)
            {
                throw new AppException(HttpStatusCode.Forbidden, "User doesn't have access to the requested routine");
            }
        }
    }
}
