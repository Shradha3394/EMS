using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Data;
using UserManagement.Data.Entities;
using UserManagement.Data.Repository.Abstract;

namespace UserManagement.Data.Repository.Concrete
{
    internal class UserRepository : IUserRepository
    {
        private readonly EmsDataContext _dataContext;

        public UserRepository(EmsDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User?> CreateUserAsync(User? user)
        {
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<User?>> GetUsersAsync()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(u => u!.Id == id);
        }

        public async Task<User?> UpdateUserAsync(User? user)
        {
            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _dataContext.Users.Remove(user);
                await _dataContext.SaveChangesAsync();
            }
        }
    }

}