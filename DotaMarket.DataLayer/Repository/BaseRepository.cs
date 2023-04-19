using Contracts;
using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotaMarket.DataLayer.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
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
            var entity = await _context.Set<T>().FindAsync(item.Id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> FindById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Update(T item)
        {
            var entity = _context.Set<T>().FindAsync(item.Id);
            _context.Entry(entity).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
        }
    }
}