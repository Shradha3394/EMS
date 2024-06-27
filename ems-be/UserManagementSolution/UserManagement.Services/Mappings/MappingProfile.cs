using AutoMapper;
using UserManagement.Common.Dtos;
using UserManagement.Common.Models;
using UserManagement.Data.Entities;

namespace UserManagement.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, CreateUserDto>();
            CreateMap<CreateUserResponse, User>();
            CreateMap<User, CreateUserResponse>();
        }

    }
}
