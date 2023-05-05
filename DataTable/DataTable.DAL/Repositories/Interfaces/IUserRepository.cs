using DataTable.DAL.Entities;
using DataTable.DAL.Enums;

namespace DataTable.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IQueryable<User> GetUsersFilteredByParameter(string parameter);
        IQueryable<User> GetUsersFilteredByRole(Role role);
        IQueryable<User> GetUsersFilteredByStatus(bool isActive);
        IQueryable<User> GetUsersSortedByEmailAsync();
        IQueryable<User> GetUsersSortedByNameAsync();
    }
}