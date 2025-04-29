using DietApp.Application.Features.DietPlans.Commands.CreateDietPlan;

public class DietPlanService
{
    public double CalculateTotalCalories(CreateMealDto meal)
    {
        return meal.MealFoods.Sum(mf => mf.Quantity * mf.Food.Calories / mf.Food.QuantityPerUnit);
    }

    public double CalculateTotalProtein(CreateMealDto meal)
    {
        return meal.MealFoods.Sum(mf => mf.Quantity * mf.Food.Protein / mf.Food.QuantityPerUnit);
    }

    // Diğer hesaplama metotları...
}
