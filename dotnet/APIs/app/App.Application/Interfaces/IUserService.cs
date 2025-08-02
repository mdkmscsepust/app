using App.Application.Models.RequestModels;
using App.Application.Models.ResponseModels;

namespace App.Application.Interfaces;

public interface IUserService
{
    Task<bool> AddAsync(UserInDTO product);

    Task<bool> UpdateAsync(int id, UserInDTO product);

    Task<UserOutDTO> GetByIdAsync(int id);

    Task<IEnumerable<UserOutDTO>> GetAllAsync();
}