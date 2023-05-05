using DataTable.DAL.Entities;

namespace DataTable.BLL.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task EditUserAsync(User editedUser, Guid id);
        Task<IEnumerable<User>> GetAllEventsAsync();
        Task<User> GetEventByIdAsync(Guid id);
    }
}