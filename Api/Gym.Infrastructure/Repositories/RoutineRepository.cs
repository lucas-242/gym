﻿using Gym.Application.Persistence;
using Gym.Application.Repositories;
using Gym.Entities;
using Gym.EntityFramework.Utils;
using Microsoft.EntityFrameworkCore;

namespace Gym.EntityFramework.Repositories
{
    internal class RoutineRepository : IRoutineRepository
    {
        private readonly IApplicationDbContext _context;

        public RoutineRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Routine? Get(int id)
        {
            var result = _context.Routines.SingleOrDefault(r => r.Id.Equals(id));
            return result;
        }
        public void Delete(Routine routine)
        {
            _context.Routines.Remove(routine);
        }

        public Routine Create(Routine routine)
        {
            _context.Routines.Add(routine);
            return routine;
        }

        public Routine Update(Routine routine)
        {
            _context.DetachLocal<Routine>(routine.Id);
            _context.Routines.Update(routine);
            return routine;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
