using CalorieCompass.Domain.Interfaces;
using CalorieCompass.Domain.Models;
using CalorieCompass.MongoDb.Contract.Models;
using CalorieCompass.MongoDb.Contract.Mappers;
using FluentResults;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CalorieCompass.MongoDb.Repositories;

public class FoodItemRepository: IFoodRepository
{
    private readonly IMongoCollection<FoodItem> _foodItemCollection;

    public FoodItemRepository(IMongoCollection<FoodItem> foodItemCollection)
    {
        _foodItemCollection = foodItemCollection;
    }

    public async Task<Result<FoodItem>> Get(string id)
    {
        var isParsed = ObjectId.TryParse(id, out var objectId);

        if(isParsed)
        {
            try
            {
                var foodItem = await _foodItemCollection.FindAsync(x => x.Id == objectId);
                
                
            }
            catch (Exception ex)
            {
                // Return
            }   
        }
        else
        {
            // Return
        }
    }
}