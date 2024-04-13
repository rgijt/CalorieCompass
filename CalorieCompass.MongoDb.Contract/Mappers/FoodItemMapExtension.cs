using CalorieCompass.Domain.Models;
using CalorieCompass.MongoDb.Contract.Models;
using MongoDB.Bson;

namespace CalorieCompass.MongoDb.Contract.Mappers;

public static class FoodItemMapExtension
{
    public static Domain.Models.FoodItem MapTo(this Models.FoodItem foodItem)
        => new Domain.Models.FoodItem{
            Id = foodItem.Id.ToString(),
            Name = foodItem.Name,
            Brand= foodItem.Brand,
            Calories= foodItem.Calories,
            Carb= foodItem.Carb,
            Description= foodItem.Description,
            Fat= foodItem.Fat,
            Protein= foodItem.Protein,
            MeasurementUnit= foodItem.MeasurementUnit,
        };

    public static Models.FoodItem? MapFrom(this Domain.Models.FoodItem foodItem)
    {
        // Parse string to Object Id
        var isParsed = ObjectId.TryParse(foodItem.Id, out var id);

        if(isParsed)
        {
            return new Models.FoodItem{
                Id = id,
                Name = foodItem.Name,
                Description = foodItem.Description,
                Brand = foodItem.Brand,
                Calories = foodItem.Calories,
                Carb = foodItem.Carb,
                Fat = foodItem.Fat,
                Protein = foodItem.Protein,
                MeasurementUnit = foodItem.MeasurementUnit
            };
        }
        else 
        {
            return null;
        }

    }
}