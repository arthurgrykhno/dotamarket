namespace Contracts
{
    public interface IRepository<T>
    {
        Task<T> FindById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T item);
        Task Update(T item);
        Task Delete(T item);
    }
}