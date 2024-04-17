using Microsoft.EntityFrameworkCore;
using PeopleViewBack.Data;
using PeopleViewBack.Interfaces;
using PeopleViewBack.Models;

namespace PeopleViewBack.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PeopleViewContext _dbContext;

        public UserRepository(PeopleViewContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> CreateUser(User user)
        {
            try
            {
                var createdUser = await _dbContext.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return createdUser.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<bool?> DeleteUser(long id)
        {
            var user = await GetUser(id);
            if (user is null)
            {
                return false;
            }
            try
            {
                _dbContext.Remove(user);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<User?> EditUser(User user)
        {
            try
            {
                var editedUser = await GetUser(user.Id);
                if (editedUser is null)
                {
                    await CreateUser(user);
                    return editedUser;
                }

                EditUserField(editedUser, user);
                await _dbContext.SaveChangesAsync();
                return editedUser;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        private static void EditUserField(User editedUser, User user)
        {
            editedUser.FirstName = user.FirstName;
            editedUser.LastName = user.LastName;
            editedUser.StreetName = user.StreetName;
            editedUser.ApartmentNumber = user.ApartmentNumber;
            editedUser.HouseNumber = user.HouseNumber;
            editedUser.DateOfBirth = user.DateOfBirth;
            editedUser.PhoneNumber = user.PhoneNumber;
            editedUser.PostalCode = user.PostalCode;
            editedUser.Town = user.Town;
        }

        public async Task<User?> GetUser(long Id)
        {
            try
            {
                return await _dbContext
                    .Set<User>()
                    .FirstOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<User?>> GetUsers()
        {
            try
            {
                return await _dbContext
                    .Set<User>()
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
