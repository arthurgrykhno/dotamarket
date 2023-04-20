using Contracts;
using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DotaMarket.DataLayer.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DotaMarketContext _context;

        public BaseRepository(DotaMarketContext context)
        {
            _context = context;
        }
      
        public async Task<T> FindOneAsync(ISpecification<T> specification)
        {
            var specificationResult = GetQuery(_context.Set<T>(),specification);
            return await specificationResult.FirstOrDefaultAsync();
        }

        public async Task<List<T>> FindAsync(ISpecification<T> specification)
        {
            var specificationResult = GetQuery(_context.Set<T>(),specification);
            return await specificationResult.ToListAsync();
        }

        public async Task AddAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            var entity = await _context.Set<T>().FindAsync(item.Id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T item)
        {
            var entity = _context.Set<T>().FindAsync(item.Id);
            _context.Entry(entity).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
        }

        public T FindById(Guid id)
        {
            return _context.Set<T>().SingleOrDefault(i => i.Id == id);
        }

        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery,
            ISpecification<T> specification)
        {
            var query = inputQuery;

            if (specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

            if (specification.OrderBy is not null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending is not null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.GroupBy is not null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip - 1)
                    .Take(specification.Take);
            }

            return query;
        }
    }
}