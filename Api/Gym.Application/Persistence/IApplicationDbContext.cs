﻿using Gym.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Gym.Application.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<BusinessHour> BusinessHours { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Execution> Executions { get; set; }
        DbSet<Exercise> Exercises { get; set; }
        DbSet<ExerciseImage> ExerciseImages { get; set; }
        DbSet<ExerciseMuscle> ExerciseMuscles { get; set; }
        DbSet<Muscle> Muscles { get; set; }
        DbSet<Routine> Routines { get; set; }
        DbSet<RefreshToken> RefreshTokens { get; set; }
        DbSet<Set> Sets { get; set; }
        DbSet<Tip> Tips { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Workout> Workouts { get; set; }
        DbSet<WorkoutExercise> WorkoutExercises { get; set; }

        public abstract EntityEntry Entry(object entity);

        public abstract DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
        Task<int> SaveChangesAsync();

    }
}
