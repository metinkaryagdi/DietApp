using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Domain.Entities;

namespace DietApp.Domain.Interfaces
{
    public interface IMealRepository
    {
        Task<Meal> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Meal> GetByIdWithFoodsAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Meal>> GetByUserAndDateAsync(Guid userId, DateTime date, CancellationToken cancellationToken = default);
        Task<IEnumerable<Meal>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Meal entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Meal entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Meal entity, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
} 