using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Services.Abstract
{
    internal interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
