namespace Interfaces
{
    public interface IRepository<T>
    {
        T ReadById(int id);
        IEnumerable<T> ReadAll();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}