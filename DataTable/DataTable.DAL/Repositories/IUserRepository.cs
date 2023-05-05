using DataTable.DAL.Entities;

namespace DataTable.DAL.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetByIdAsync(Guid id);
        void RemoveUser(User user);
        void UpdateUser(User user);
    }
}