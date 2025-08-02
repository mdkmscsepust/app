using App.Domain.Entities;

namespace App.Domain.Interfaces;

public interface IUserRepository
{
    Task<bool> AddAsync(User user);

    Task<bool> UpdateAsync(User user);

    Task<User> GetByIdAsync(int id);

    Task<IEnumerable<User>> GetAllAsync();
}