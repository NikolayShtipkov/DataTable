using DataTable.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataTable.DAL.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
