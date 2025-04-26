using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Domain.Entities;

namespace DietApp.Domain.Interfaces
{
    public interface IDietPlanRepository
    {
        Task<DietPlan?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<DietPlan>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<DietPlan> AddAsync(DietPlan dietPlan, CancellationToken cancellationToken = default);
        Task UpdateAsync(DietPlan dietPlan, CancellationToken cancellationToken = default);
        Task DeleteAsync(DietPlan dietPlan, CancellationToken cancellationToken = default);
    }
}
