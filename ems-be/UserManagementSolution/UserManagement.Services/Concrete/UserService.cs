using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Common.Dtos;
using UserManagement.Common.Models;
using UserManagement.Services.Abstract;
using UserManagement.Data;
using UserManagement.Data.Entities;
using UserManagement.Data.Repository.Abstract;
using UserManagement.Services.Mappings.UserManagement.Common.Mappings;

namespace UserManagement.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserDto user)
        {
            var newUser = await _userRepository.CreateUserAsync(user.ToUser());
            return newUser.ToCreateUserResponse();
        }

        public async Task<List<CreateUserResponse>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            return users.ToCreateUserResponseList();
        }

        public async Task<CreateUserResponse> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return user.ToCreateUserResponse();
        }

        public async Task<CreateUserResponse> UpdateUserAsync(CreateUserDto user)
        {
            var newUser = await _userRepository.UpdateUserAsync(user.ToUser());
            return newUser.ToCreateUserResponse();
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
