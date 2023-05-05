using DataTable.DAL.Data;
using DataTable.DAL.Entities;
using DataTable.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataTable.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public IQueryable<User> GetUsersSortedByNameAsync()
        {
            return _context.Users.OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName);
        }

        public IQueryable<User> GetUsersSortedByEmailAsync()
        {
            return _context.Users.OrderBy(u => u.Email);
        }

        public IQueryable<User> GetUsersFilteredByParameter(string parameter)
        {
            return _context.Users.Where(u =>
                u.FirstName.Contains(parameter) ||
                u.LastName.Contains(parameter) ||
                u.Email.Contains(parameter));
        }
    }
}
