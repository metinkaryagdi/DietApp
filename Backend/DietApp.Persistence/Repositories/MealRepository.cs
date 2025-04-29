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
    public class MealRepository : IMealRepository
    {
        private readonly ApplicationDbContext _context;

        public MealRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Meal> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Meals
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        }

        public async Task<Meal> GetByIdWithFoodsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Meals
                .Include(m => m.MealFoods)
                    .ThenInclude(mf => mf.Food)
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Meal>> GetByUserAndDateAsync(Guid userId, DateTime date, CancellationToken cancellationToken = default)
        {
            return await _context.Meals
                .Include(m => m.MealFoods)
                    .ThenInclude(mf => mf.Food)
                .Where(m => m.UserId == userId && m.MealTime.Date == date.Date)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Meal>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Meals
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Meal entity, CancellationToken cancellationToken = default)
        {
            await _context.Meals.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Meal entity, CancellationToken cancellationToken = default)
        {
            _context.Meals.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Meal entity, CancellationToken cancellationToken = default)
        {
            _context.Meals.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}