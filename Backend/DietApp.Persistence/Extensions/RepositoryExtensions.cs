using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietApp.Persistence.Extensions
{
    public static class RepositoryExtensions
    {
        public static IQueryable<User> IncludeUserRelations(this IQueryable<User> query)
        {
            return query
                .Include(u => u.Meals)
                .Include(u => u.DailyNutritions);
        }

        public static IQueryable<User> AsNoTracking(this IQueryable<User> query)
        {
            return query.AsNoTracking();
        }

        public static async Task<User> GetUserWithRelationsAsync(
            this IQueryable<User> query,
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            return await query
                .IncludeUserRelations()
                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        }

        public static async Task<User> GetUserByEmailWithRelationsAsync(
            this IQueryable<User> query,
            string email,
            CancellationToken cancellationToken = default)
        {
            return await query
                .IncludeUserRelations()
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower(), cancellationToken);
        }
    }
} 