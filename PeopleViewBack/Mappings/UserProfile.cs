using AutoMapper;
using PeopleViewBack.DTOs;
using PeopleViewBack.Models;

namespace PeopleViewBack.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, CreateUserDto>()
                .ReverseMap();

            CreateMap<User, EditUserDto>()
                .ReverseMap();

            CreateMap<User, GetUserDto>()
                .ReverseMap();
        }
    }
}
