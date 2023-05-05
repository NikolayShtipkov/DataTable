using DataTable.DAL.Entities;

namespace DataTable.DAL.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<IEnumerable<User>> GetUsersSortedByEmailAsync();
        Task<IEnumerable<User>> GetUsersSortedByNameAsync();
        void RemoveUser(User user);
        Task SaveChangesAsync();
        void UpdateUser(User user);
    }
}