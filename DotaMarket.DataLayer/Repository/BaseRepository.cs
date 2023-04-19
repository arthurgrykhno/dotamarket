using Contracts;

namespace DotaMarket.DataLayer.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DotaMarketContext _context;

        public BaseRepository(DotaMarketContext context)
        {
            _context = context;
        }

        public async Task Add(T item)
        {
            await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T item)
        {
           await _context.Set<T>().Remove(item);
           await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}