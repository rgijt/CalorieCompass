using CalorieCompass.Domain.Models;
using FluentResults;

namespace CalorieCompass.Domain.Interfaces;

public interface IFoodService
{
    Task<Result<FoodItem>> GetAsync(Guid id);
}