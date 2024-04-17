using PeopleViewBack.Models;

namespace PeopleViewBack.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> CreateUser(User newNodeDto);
        Task<bool?> DeleteUser(long Id);
        Task<IEnumerable<User?>> GetUsers();
        Task<User?> GetUser(long Id);
        Task<User?> EditUser(User renameNodeDto);
    }
}
