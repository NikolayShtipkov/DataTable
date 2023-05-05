using DataTable.DAL.Data;
using DataTable.DAL.Entities;
using DataTable.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataTable.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected DatabaseContext _context;
        protected DbSet<T> _entity;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entity.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task InsertAsync(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entity.Update(entity);
        }

        public void Delete(T entity)
        {
            _entity.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
