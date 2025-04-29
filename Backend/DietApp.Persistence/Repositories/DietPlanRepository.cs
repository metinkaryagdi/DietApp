using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Domain.Entities;
using DietApp.Domain.Interfaces;
using DietApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DietApp.Persistence.Repositories
{
    public class DietPlanRepository : IDietPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public DietPlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DietPlan> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.DietPlans
                .Include(dp => dp.Meals)
                .FirstOrDefaultAsync(dp => dp.Id == id, cancellationToken);
        }

        public async Task<DietPlan> GetActiveDietPlanAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _context.DietPlans
                .Include(dp => dp.Meals)
                .FirstOrDefaultAsync(dp => dp.UserId == userId && dp.IsActive, cancellationToken);
        }

        public async Task<IEnumerable<DietPlan>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.DietPlans
                .AsNoTracking()
                .Include(dp => dp.Meals)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(DietPlan entity, CancellationToken cancellationToken = default)
        {
            await _context.DietPlans.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(DietPlan entity, CancellationToken cancellationToken = default)
        {
            _context.DietPlans.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(DietPlan entity, CancellationToken cancellationToken = default)
        {
            _context.DietPlans.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
