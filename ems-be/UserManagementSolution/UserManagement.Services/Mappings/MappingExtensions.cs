using AutoMapper;
using UserManagement.Common.Dtos;
using UserManagement.Common.Models;
using UserManagement.Data.Entities;

namespace UserManagement.Services.Mappings
{
    namespace UserManagement.Common.Mappings
    {
        public static class MappingExtensions
        {
            private static IMapper _mapper;

            public static void ConfigureMapper(IMapper mapper)
            {
                _mapper = mapper;
            }

            public static User ToUser(this CreateUserDto source)
            {
                return _mapper.Map<User>(source);
            }

            public static CreateUserResponse ToCreateUserResponse(this User source)
            {
                return _mapper.Map<CreateUserResponse>(source);
            }

            public static List<CreateUserResponse> ToCreateUserResponseList(this List<User> source)
            {
                return _mapper.Map<List<CreateUserResponse>>(source);
            }
        }
    }
}
