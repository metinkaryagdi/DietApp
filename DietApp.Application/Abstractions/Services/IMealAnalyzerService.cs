using DietApp.Domain.Entities;

namespace DietApp.Application.Abstractions.Services
{
    public interface IMealAnalyzerService
    {
        Task AnalyzeMealAsync(Meal meal, CancellationToken cancellationToken = default);
    }
}
