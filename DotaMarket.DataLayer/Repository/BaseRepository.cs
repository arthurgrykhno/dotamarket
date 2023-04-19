using Interfaces;

namespace DotaMarket.DataLayer.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DotaMarketContext _context;

        public BaseRepository(DotaMarketContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public IEnumerable<T> ReadAll()
        {
           return _context.Set<T>();
        }

        public T ReadById(int id)
        {
            return _context.Set<T>().Find(id); ;
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }
}