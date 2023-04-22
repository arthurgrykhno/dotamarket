namespace Contracts
{
    public interface IRepository<T>
    {
        T FindById<TEntity>(Guid id);
        Task<T> FindOneAsync<TEntity>(ISpecification<T> specification);
        Task<IEnumerable<T>> FindAsync<TEntity>(ISpecification<T> specification); 
        Task<IEnumerable<T>> GetAllAsync<TEntity>();
        Task<T> AddAsync<TEntity>(T item);
        Task<T> UpdateAsync<TEntity>(T item);
        Task DeleteAsync<TEntity>(T item);
        Task<IEnumerable<T>> AddRangeAsync<TEntity>(IEnumerable<T> item);
        Task<IEnumerable<T>> UpdateRangeAsync<TEntity>(IEnumerable<T> item);
        Task DeleteRangeAsync<TEntity>(IEnumerable<T> item);
    }
}