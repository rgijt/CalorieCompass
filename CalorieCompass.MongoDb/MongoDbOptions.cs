namespace CalorieCompass.MongoDb;

public class MongoDbOptions
{
    public const string DEFAULT_CONFIG_KEY = "MongoDbOptions";

    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string FoodItemCollectionName { get; set; } = string.Empty;
}