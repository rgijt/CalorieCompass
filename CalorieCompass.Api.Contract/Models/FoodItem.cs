using System.ComponentModel.DataAnnotations;

namespace CalorieCompass.Api.Contract.Models;

public class FoodItem : IValidatableObject
{
    [Required]
    public string Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Brand { get; set; }

    // Nutrion values are stored per 100 grams.
    [Required]
    public double Calories { get; set; }

    [Required]
    public double Fat { get; set; }

    [Required]
    public double Protein { get; set; }

    [Required]
    public double Carb { get; set; }

    [Required]
    public string MeasurementUnit { get; set; } = "Metric";

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Calories < 0)
        {
            results.Add(new ValidationResult("Calories must be a non-negative number.", new[] { nameof(Calories) }));
        }

        if (Fat < 0)
        {
            results.Add(new ValidationResult("Fat must be a non-negative number.", new[] { nameof(Fat) }));
        }

        if (Protein < 0)
        {
            results.Add(new ValidationResult("Protein must be a non-negative number.", new[] { nameof(Protein) }));
        }

        if (Carb < 0)
        {
            results.Add(new ValidationResult("Carb must be a non-negative number.", new[] { nameof(Carb) }));
        }

        // Add more custom validation logic as needed

        return results;
    }
}