using DataTable.DAL.Entities;

namespace DataTable.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        void Delete(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task InsertAsync(T entity);
        Task SaveChangesAsync();
        void Update(T entity);
    }
}