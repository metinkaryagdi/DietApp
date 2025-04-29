using DietApp.Domain.Entities;
using DietApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DietApp.Application.Features.DietPlans.Commands.CreateDietPlan
{
    public class CreateDietPlanHandler : IRequestHandler<CreateDietPlanCommand, Guid>
    {
        private readonly IDietPlanRepository _dietPlanRepository;
        private readonly IUserRepository _userRepository;

        public CreateDietPlanHandler(IDietPlanRepository dietPlanRepository, IUserRepository userRepository)
        {
            _dietPlanRepository = dietPlanRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateDietPlanCommand request, CancellationToken cancellationToken)
        {
            // TODO: Get the current user's ID from the authentication context
            var currentUserId = Guid.Parse("00000000-0000-0000-0000-000000000001"); // Temporary hardcoded user ID

            var dietPlan = new DietPlan
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                UserId = currentUserId
            };

            foreach (var mealDto in request.Meals)
            {
                var meal = new Meal
                {
                    Id = Guid.NewGuid(),
                    Name = mealDto.Name,
                    MealTime = mealDto.MealTime,
                    TotalCalories = mealDto.TotalCalories,
                    TotalProtein = mealDto.TotalProtein,
                    TotalCarbohydrate = mealDto.TotalCarbohydrate,
                    TotalFat = mealDto.TotalFat,
                    CreatedDate = DateTime.UtcNow,
                    UserId = currentUserId,
                    DietPlanId = dietPlan.Id
                };

                foreach (var mealFoodDto in mealDto.MealFoods)
                {
                    var food = new Food
                    {
                        Id = Guid.NewGuid(),
                        Name = mealFoodDto.Food.Name,
                        Description = mealFoodDto.Food.Description,
                        Calories = mealFoodDto.Food.Calories,
                        Protein = mealFoodDto.Food.Protein,
                        Carbohydrate = mealFoodDto.Food.Carbohydrate,
                        Fat = mealFoodDto.Food.Fat,
                        Unit = mealFoodDto.Food.Unit,
                        QuantityPerUnit = mealFoodDto.Food.QuantityPerUnit,
                        CreatedDate = DateTime.UtcNow,
                        IsActive = true
                    };

                    var mealFood = new MealFood
                    {
                        Id = Guid.NewGuid(),
                        Quantity = mealFoodDto.Quantity,
                        Calories = mealFoodDto.Food.Calories * (mealFoodDto.Quantity / mealFoodDto.Food.QuantityPerUnit),
                        Protein = mealFoodDto.Food.Protein * (mealFoodDto.Quantity / mealFoodDto.Food.QuantityPerUnit),
                        Carbohydrate = mealFoodDto.Food.Carbohydrate * (mealFoodDto.Quantity / mealFoodDto.Food.QuantityPerUnit),
                        Fat = mealFoodDto.Food.Fat * (mealFoodDto.Quantity / mealFoodDto.Food.QuantityPerUnit),
                        CreatedDate = DateTime.UtcNow,
                        Food = food,
                        MealId = meal.Id
                    };

                    meal.MealFoods.Add(mealFood);
                }

                dietPlan.Meals.Add(meal);
            }

            await _dietPlanRepository.AddAsync(dietPlan, cancellationToken);
            return dietPlan.Id;
        }
    }
}