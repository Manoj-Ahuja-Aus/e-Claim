namespace CustomerPortal.Api.Persistence
{
    /// <summary>
    /// Interface for a generic repository providing basic CRUD operations.
    /// </summary>
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
