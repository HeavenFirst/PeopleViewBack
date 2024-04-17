using AutoMapper;
using PeopleViewBack.DTOs;
using PeopleViewBack.Interfaces;
using PeopleViewBack.Models;

namespace PeopleViewBack.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserDto?> CreateUser(CreateUserDto newUserDto)
        {
            var newUser = await _userRepository.CreateUser(_mapper.Map<User>(newUserDto));
            return _mapper.Map<CreateUserDto>(newUser);
        }

        public async Task<bool?> DeleteUser(long Id) =>
            await _userRepository.DeleteUser(Id);

        public async Task<IEnumerable<GetUserDto?>> GetUsers()
        {
            var user = await _userRepository.GetUsers();
            return _mapper.Map<IEnumerable<GetUserDto?>>(user);
        }

        public async Task<GetUserDto?> GetUser(long id)
        {
            var user = await _userRepository.GetUser(id);
            return _mapper.Map<GetUserDto?>(user);
        }

        public async Task<EditUserDto?> EditUser(EditUserDto editUserDto)
        {
            var user = await _userRepository.EditUser(_mapper.Map<User>(editUserDto));
            return _mapper.Map<EditUserDto>(user);
        }
    }
}

