namespace CalorieCompass.Domain.Models;

public class FoodItem
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Brand { get; set; }

    // Nutrion values are stored per 100 grams.
    public double Calories { get; set; }
    public double Fat { get; set; }
    public double Protein { get; set; }
    public double Carb { get; set; }
    public string MeasurementUnit { get; set; } = "metric";
}