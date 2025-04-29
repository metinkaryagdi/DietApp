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
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Food> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Foods
                .Include(f => f.MealFoods)
                .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
        }

        public async Task<Food> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Foods
                .FirstOrDefaultAsync(f => f.Name.ToLower() == name.ToLower(), cancellationToken);
        }

        public async Task<IEnumerable<Food>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Foods
                .Include(f => f.MealFoods)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Food>> GetByCategoryAsync(string category, CancellationToken cancellationToken = default)
        {
            return await _context.Foods
                .AsNoTracking()
                .Where(f => f.Category.ToLower() == category.ToLower())
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Food entity, CancellationToken cancellationToken = default)
        {
            await _context.Foods.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Food entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Food entity, CancellationToken cancellationToken = default)
        {
            _context.Foods.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
} 