using DataTable.DAL.Entities;

namespace DataTable.DAL.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        void RemoveUser(User user);
        Task SaveChangesAsync();
        void UpdateUser(User user);
    }
}