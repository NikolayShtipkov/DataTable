using DataTable.DAL.Entities;
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
            return _userRepository.GetUsersSortedByNameAsync();
        }

        public IEnumerable<User> GetUsersSortedByEmail()
        {
            return _userRepository.GetUsersSortedByEmailAsync();
        }

        public IEnumerable<User> GetUsersFilteredByParameter(string parameter)
        {
            return _userRepository.GetUsersFilteredByParameter(parameter);
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception();
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
                throw new Exception();
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
                throw new Exception();
            }

            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
