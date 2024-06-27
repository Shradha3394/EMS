using UserManagement.Common.Dtos;
using UserManagement.Common.Models;

namespace UserManagement.Services.Abstract
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(CreateUserDto user);
        Task<List<CreateUserResponse>> GetUsersAsync();
        Task<CreateUserResponse> GetUserByIdAsync(int id);
        Task<CreateUserResponse> UpdateUserAsync(CreateUserDto user);
        Task DeleteUserAsync(int id);
    }
}
