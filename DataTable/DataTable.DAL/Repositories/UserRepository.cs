using DataTable.DAL.Data;
using DataTable.DAL.Entities;
using DataTable.DAL.Enums;
using DataTable.DAL.Repositories.Interfaces;

namespace DataTable.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public IQueryable<User> GetUsersSortedByName()
        {
            return _entity.OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName);
        }

        public IQueryable<User> GetUsersSortedByEmail()
        {
            return _entity.OrderBy(u => u.Email);
        }

        public IQueryable<User> GetUsersFilteredByParameter(string parameter)
        {
            return _entity.Where(u =>
                u.FirstName.Contains(parameter) ||
                u.LastName.Contains(parameter) ||
                u.Email.Contains(parameter));
        }

        public IQueryable<User> GetUsersFilteredByRole(Role role)
        {
            return _entity.Where(u => u.Role == role);
        }

        public IQueryable<User> GetUsersFilteredByStatus(bool isActive)
        {
            return _entity.Where(u => u.IsActive == isActive);
        }
    }
}
