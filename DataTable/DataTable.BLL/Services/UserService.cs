using DataTable.DAL.Entities;
using DataTable.DAL.Repositories;

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
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<IEnumerable<User>> GetUsersSortedByNameAsync()
        {
            return await _userRepository.GetUsersSortedByNameAsync();
        }

        public async Task<IEnumerable<User>> GetUsersSortedByEmailAsync()
        {
            return await _userRepository.GetUsersSortedByEmailAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new Exception();
            }

            return user;
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.CreateUserAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task EditUserAsync(User editedUser, Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new Exception();
            }

            user.FirstName = editedUser.FirstName;
            user.LastName = editedUser.LastName;
            user.Email = editedUser.Email;
            user.Role = editedUser.Role;
            user.IsActive = editedUser.IsActive;

            _userRepository.UpdateUser(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new Exception();
            }

            _userRepository.RemoveUser(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
