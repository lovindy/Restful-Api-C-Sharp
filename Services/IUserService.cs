using System.Collections.Generic;
using System.Threading.Tasks;
using MyRestApi.Models;
using MyRestApi.Models.DTOs;

namespace MyRestApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(UserCreateDto userDto);
        Task<User> UpdateUserAsync(int id, UserUpdateDto userDto);
        Task DeleteUserAsync(int id);
        Task<User> AuthenticateAsync(string email, string password);
    }
}