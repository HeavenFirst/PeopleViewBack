using PeopleViewBack.DTOs;

namespace PeopleViewBack.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserDto?> CreateUser(CreateUserDto newUserDto);
        Task<bool?> DeleteUser(long Id);
        Task<IEnumerable<GetUserDto?>> GetUsers();
        Task<GetUserDto?> GetUser(long Id);
        Task<EditUserDto?> EditUser(EditUserDto editUserDto);
    }
}
