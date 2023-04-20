namespace Contracts
{
    public interface IRepository<T>
    {
        T FindById(Guid id);
        Task<T> FindOneAsync(ISpecification<T> specification);
        Task<List<T>> FindAsync(ISpecification<T> specification); 
        Task<IEnumerable<T>> GetAllAsync<TEntity>();
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<T> DeleteAsync(T item);
        IAsyncEnumerable<T> AddRangeAsync(IEnumerable<T> item);
        IAsyncEnumerable<T> UpdateRangeAsync(IEnumerable<T> item);
        IAsyncEnumerable<T> DeleteRangeAsync(IEnumerable<T> item);
    }
}