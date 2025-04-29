using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Domain.Entities;

namespace DietApp.Domain.Interfaces
{
    public interface IDailyNutritionRepository
    {
        Task<DailyNutrition> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<DailyNutrition> GetByUserAndDateAsync(Guid userId, DateTime date, CancellationToken cancellationToken = default);
        Task<IEnumerable<DailyNutrition>> GetByDateRangeAsync(Guid userId, DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
        Task<IEnumerable<DailyNutrition>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(DailyNutrition entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(DailyNutrition entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(DailyNutrition entity, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
} 