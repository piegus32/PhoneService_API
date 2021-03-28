using AutoMapper;
using PhoneService_API.Dtos;
using PhoneService_API.Models;

namespace PhoneService_API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<UserReadDto, User>();

            CreateMap<User, UserCreateDto>();
            CreateMap<User, UserReadDto>();
        }
    }
}
