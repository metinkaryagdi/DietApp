using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Domain.Entities;

namespace DietApp.Domain.Interfaces
{
    public interface IFoodRepository
    {
        Task<Food> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Food> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<IEnumerable<Food>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Food>> GetByCategoryAsync(string category, CancellationToken cancellationToken = default);
        Task AddAsync(Food entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Food entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Food entity, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
} 