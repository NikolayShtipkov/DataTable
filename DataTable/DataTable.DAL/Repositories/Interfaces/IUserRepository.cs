using DataTable.DAL.Entities;

namespace DataTable.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IQueryable<User> GetUsersFilteredByParameter(string parameter);
        IQueryable<User> GetUsersSortedByEmailAsync();
        IQueryable<User> GetUsersSortedByNameAsync();
    }
}