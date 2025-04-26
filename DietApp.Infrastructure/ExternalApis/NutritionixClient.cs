namespace DietApp.Infrastructure.ExternalApis
{
    public class NutritionixClient
    {
        public string GetNutritionalInfo(string foodItem)
        {
            // Gerçek dış servis entegrasyonu burada yapılacak. Örnek olarak bir API isteği yapılabilir.
            return $"Nutritional information for {foodItem}: 200 kcal";
        }
    }
}
