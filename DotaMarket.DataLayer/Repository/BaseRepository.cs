using Contracts;
using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DotaMarket.DataLayer.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DotaMarketContext _context;

        public BaseRepository(DotaMarketContext context)
        {
            _context = context;
        }
      
        public async Task<T> FindOneAsync<TEntity>(ISpecification<T> specification)
        {
            var specificationResult = GetQuery(_context.Set<T>(),specification);
            return await specificationResult.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> FindAsync<TEntity>(ISpecification<T> specification)
        {
            var specificationResult = GetQuery(_context.Set<T>(), specification);
            return await specificationResult.ToListAsync();
        }

        public async Task<T> AddAsync<TEntity>(T item)
        {
            await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<T>> AddRangeAsync<TEntity>(IEnumerable<T> items)
        {
            await _context.Set<T>().AddRangeAsync(items);
            await _context.SaveChangesAsync();
            return items;
        }

        public void DeleteAsync<TEntity>(T item)
        {  
             _context.Set<T>().Remove(item);
             _context.SaveChanges();         
        }

        public void DeleteRangeAsync<TEntity>(IEnumerable<T> items)
        {
            _context.Set<T>().RemoveRange(items);
            _context.SaveChanges();  
        }

        public async Task<IEnumerable<T>> GetAllAsync<TEntity>()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> UpdateAsync<TEntity>(T item)
        {
            var entity = _context.Set<T>().FindAsync(item.Id);
            _context.Entry(entity).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<T>> UpdateRangeAsync<TEntity>(IEnumerable<T> items)
        {
            _context.Set<T>().UpdateRange(items);
            _context.SaveChanges();
            return items;
        }

        public T FindById<TEntity>(Guid id)
        {
            return _context.Set<T>().SingleOrDefault(i => i.Id == id);
        }

        private static IQueryable<T> GetQuery(IQueryable<T> inputQuery,
            ISpecification<T> specification)
        {
            var query = inputQuery;

            if (specification.Criterias != null && specification.Criterias.Any())
            {
                var combinedCriteria = specification.Criterias.Aggregate(
                    (c1, c2) => Expression.Lambda<Func<T, bool>>(
                        Expression.AndAlso(c1.Body, c2.Body), c1.Parameters));
                query = query.Where(combinedCriteria);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.GroupBy != null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            if (specification.IsPagingEnabled)
            {
                query = query
                    .Skip(specification.Skip - 1)
                    .Take(specification.Take);
            }
            return query;
        }
    }
}