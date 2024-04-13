using CalorieCompass.Domain.Interfaces;
using CalorieCompass.MongoDb.Contract.Models;
using CalorieCompass.MongoDb.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CalorieCompass.MongoDb;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        // Read MongoDB settings from configuration
        var mongoDbOptions = configuration.GetSection("MongoDbOptions").Get<MongoDbOptions>() 
            ?? throw new ArgumentNullException("MongoDbOptions couldn't be filled. Make sure you've added your options to appsettings.json");

        // Register Mongo
        services.RegisterMongo(mongoDbOptions);

        // Register Repositories
        services.RegisterFoodRepository(mongoDbOptions);

        return services;
    }

    private static IServiceCollection RegisterMongo(this IServiceCollection services, MongoDbOptions mongoDbOptions)
    {
        // Register MongoDB client
        services.AddSingleton<IMongoClient>(sp => new MongoClient(mongoDbOptions.ConnectionString));

        // Register MongoDB Database
        services.AddSingleton(sp => {
            var mongoClient = sp.GetService<IMongoClient>() 
                ?? throw new ArgumentNullException("Couldn't establish a connection with your MongoClient. Please validate your ConnectionString.");

            return mongoClient.GetDatabase(mongoDbOptions.DatabaseName);
        });

        return services;
    }

    private static IServiceCollection RegisterFoodRepository(this IServiceCollection services, MongoDbOptions mongoDbOptions)
    {
        // Register FoodItem collection
        services.AddSingleton(sp => addCollection<FoodItem>(sp, mongoDbOptions.FoodItemCollectionName));

        // Register FoodRepository
        services.AddScoped<IFoodRepository, FoodItemRepository>();

        return services;
    }

    private static IMongoCollection<T> addCollection<T>(IServiceProvider sp, string collectionName)
    {
        var mongoDatabase = sp.GetService<IMongoDatabase>();

        if(mongoDatabase == null)
        {
            throw new ArgumentNullException("Mongo database doesn't exist. Please check your configuration.");
        }

        return mongoDatabase.GetCollection<T>(collectionName);
    }
}