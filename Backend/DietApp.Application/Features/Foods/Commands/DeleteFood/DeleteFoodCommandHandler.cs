using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DietApp.Domain.Interfaces;

namespace DietApp.Application.Features.Foods.Commands.DeleteFood
{
    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand>
    {
        private readonly IFoodRepository _foodRepository;

        public DeleteFoodCommandHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<Unit> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
        {
            var food = await _foodRepository.GetByIdAsync(request.Id);
            if (food == null)
            {
                throw new System.Exception("Yiyecek bulunamadı.");
            }

            await _foodRepository.DeleteAsync(food);
            return Unit.Value;
        }
    }
} 