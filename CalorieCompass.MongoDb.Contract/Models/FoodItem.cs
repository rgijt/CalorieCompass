using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CalorieCompass.MongoDb.Contract.Models;

public class FoodItem
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Brand { get; set; }

    // Nutrion values are stored per 100 grams.
    public double Calories { get; set; }
    public double Carb { get; set; }
    public double Protein { get; set; }
    public double Fat { get; set; }
    public string MeasurementUnit { get; set; } = "Metric";
}