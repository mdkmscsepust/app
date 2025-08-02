using App.Application.Interfaces;
using App.Application.Models.RequestModels;
using App.Application.Models.ResponseModels;
using App.Domain.Entities;
using App.Domain.Interfaces;

namespace App.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<bool> AddAsync(UserInDTO request)
    {
        try
        {
            var user = new User
            {
                Username = request.Username,
                Email = new Domain.ValueObject.Email(request.Email),
                Contact = new Domain.ValueObject.Contact(request.CountryCode, request.PhoneNumber)
            };
            return await userRepository.AddAsync(user);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<UserOutDTO>> GetAllAsync()
    {
        try
        {
            var users = await userRepository.GetAllAsync();
            var userOuDTOList = new List<UserOutDTO>();
            foreach (var user in users)
            {
                userOuDTOList.Add(new UserOutDTO
                {
                    Username = user.Username,
                    Contact = user.Contact,
                    Email = user.Email,
                    Id = user.Id,
                    Status = user.Status
                });
            }
            return userOuDTOList;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<UserOutDTO> GetByIdAsync(int id)
    {
        try
        {
            var user = await userRepository.GetByIdAsync(id);
            var userOutDTO = new UserOutDTO
            {
                Username = user.Username,
                Contact = user.Contact,
                Email = user.Email,
                Id = user.Id,
                Status = user.Status
            };
            
            return userOutDTO;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<bool> UpdateAsync(int id, UserInDTO product)
    {
        throw new NotImplementedException();
    }
}