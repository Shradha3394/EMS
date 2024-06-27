using UserManagement.Data.Entities;

namespace UserManagement.Data.Repository.Abstract;

public interface IUserRepository
{
    Task<List<User?>> GetUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> CreateUserAsync(User? user);
    Task<User?> UpdateUserAsync(User? user);
    Task DeleteUserAsync(int id);
}