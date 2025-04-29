using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Domain.Entities;

namespace DietApp.Domain.Interfaces
{
    public interface IDietPlanRepository
    {
        Task<DietPlan> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<DietPlan> GetActiveDietPlanAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<IEnumerable<DietPlan>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(DietPlan entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(DietPlan entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(DietPlan entity, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
