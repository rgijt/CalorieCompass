using CalorieCompass.Domain.Models;

namespace CalorieCompass.Api.Contract.Mappers;

public static class FoodItemMapExtension
{
    /// <summary>
    /// Converts Domain.FoodItem to Api.Contract.Models.FoodItem.
    /// </summary>
    /// <param name="item">Domain.FoodItem</param>
    /// <returns></returns>
    public static Models.FoodItem Map(this FoodItem item)
        => new() {
            Id=item.Id,
            Name = item.Name,
            Description=item.Description,
            Brand= item.Brand,
            Calories=item.Calories,
            Carb=item.Carb,
            Protein=item.Protein,
            Fat=item.Fat,
            MeasurementUnit=item.MeasurementUnit,
        };
}