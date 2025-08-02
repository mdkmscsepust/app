using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Services;

public class UserRepository(ApplicationDbContext _dbContext) : IUserRepository
{
    public async Task<bool> AddAsync(User user)
    {
        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _dbContext.Users.FindAsync(id) ?? new User();
    }

    public async Task<bool> UpdateAsync(User user)
    {
        _dbContext.Update(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}