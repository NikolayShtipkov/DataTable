using DataTable.DAL.Entities;
using DataTable.DAL.Enums;

namespace DataTable.BLL.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task EditUserAsync(User editedUser, Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        IEnumerable<User> GetUsersFilteredByParameter(string parameter);
        IEnumerable<User> GetUsersFilteredByRole(int number);
        IEnumerable<User> GetUsersFilteredByStatus(int number);
        IEnumerable<User> GetUsersSortedByEmail();
        IEnumerable<User> GetUsersSortedByName();
    }
}