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
    public class DailyNutritionRepository : IDailyNutritionRepository
    {
        private readonly ApplicationDbContext _context;

        public DailyNutritionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DailyNutrition> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.DailyNutritions
                .FirstOrDefaultAsync(dn => dn.Id == id, cancellationToken);
        }

        public async Task<DailyNutrition> GetByUserAndDateAsync(Guid userId, DateTime date, CancellationToken cancellationToken = default)
        {
            return await _context.DailyNutritions
                .FirstOrDefaultAsync(dn => dn.UserId == userId && dn.Date.Date == date.Date, cancellationToken);
        }

        public async Task<IEnumerable<DailyNutrition>> GetByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            return await _context.DailyNutritions
                .Where(dn => dn.UserId == userId && dn.Date.Date >= startDate.Date && dn.Date.Date <= endDate.Date)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<DailyNutrition>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.DailyNutritions
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(DailyNutrition entity, CancellationToken cancellationToken = default)
        {
            await _context.DailyNutritions.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(DailyNutrition entity, CancellationToken cancellationToken = default)
        {
            _context.DailyNutritions.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(DailyNutrition entity, CancellationToken cancellationToken = default)
        {
            _context.DailyNutritions.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}