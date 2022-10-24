using Gym.Application.Persistence;
using Gym.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gym.EntityFramework.Utils
{
    internal static class ApplocationDbContextExtensions
    {
        public static void DetachLocalById<TEntity>(this IApplicationDbContext context, int id) where TEntity : BaseEntity
        {
            var predicate = (TEntity e) => e.Id == id;
            DetachLocal(context, predicate);
        }

        public static void DetachLocal<TEntity>(this IApplicationDbContext context, Func<TEntity, bool> predicate) where TEntity : class
        {
            var local = context.Set<TEntity>().Local.Where(predicate).FirstOrDefault();
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
        }
    }
}
