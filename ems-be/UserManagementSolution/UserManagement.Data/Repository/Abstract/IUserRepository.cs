using UserManagement.Data.Entities;

namespace UserManagement.Data.Repository.Abstract
{
    internal interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
    }
}
