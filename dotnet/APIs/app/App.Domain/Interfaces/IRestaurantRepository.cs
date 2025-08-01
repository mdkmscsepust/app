using App.Domain.Entities;

namespace App.Domain.Interfaces;

public interface IRestaurantRepository
{
    Task<bool> AddAsync(Restaurant restaurant);
    Task<IEnumerable<Restaurant>> GetAllAsync();
}