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

        public async Task<User> CreateUserAsync(User user)
        {
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }
    }
}