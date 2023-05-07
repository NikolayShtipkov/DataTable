using DataTable.DAL.Entities;
using DataTable.DAL.Enums;
using DataTable.DAL.Repositories.Interfaces;

namespace DataTable.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public IEnumerable<User> GetUsersSortedByName()
        {
            return _userRepository.GetUsersSortedByName();
        }

        public IEnumerable<User> GetUsersSortedByEmail()
        {
            return _userRepository.GetUsersSortedByEmail();
        }

        public IEnumerable<User> GetUsersFilteredByParameter(string parameter)
        {
            return _userRepository.GetUsersFilteredByParameter(parameter);
        }

        public IEnumerable<User> GetUsersFilteredByRole(int number)
        {
            var role = (Role)number;
            return _userRepository.GetUsersFilteredByRole(role);
        }

        public IEnumerable<User> GetUsersFilteredByStatus(int number)
        {
            bool isActive = number == 0 ? false : true;
            return _userRepository.GetUsersFilteredByStatus(isActive);
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User doesn't exist.");
            }

            return user;
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.InsertAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task EditUserAsync(User editedUser, Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User doesn't exist.");
            }

            user.FirstName = editedUser.FirstName;
            user.LastName = editedUser.LastName;
            user.Email = editedUser.Email;
            user.Role = editedUser.Role;
            user.IsActive = editedUser.IsActive;

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User doesn't exist.");
            }

            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
