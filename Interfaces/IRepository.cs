namespace Contracts
{
    public interface IRepository<T>
    {
        T FindById(Guid id);
        Task<T> FindOneAsync(ISpecification<T> specification);
        Task<List<T>> FindAsync(ISpecification<T> specification); 
        Task<IEnumerable<T>> GetAll();
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}