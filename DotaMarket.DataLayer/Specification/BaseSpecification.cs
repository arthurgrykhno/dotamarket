using Contracts;
using System.Linq.Expressions;

namespace DotaMarket.DataLayer.Specification
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public List<Expression<Func<T, bool>>> Criterias { get; private set; } = default!;
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> IncludeStrings { get; } = new();
        public Expression<Func<T, object>> OrderBy { get; private set; } = default!;
        public Expression<Func<T, object>> OrderByDescending { get; private set; } = default!;
        public Expression<Func<T, object>> GroupBy { get; private set; } = default!;

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; }

        protected void ApplyIncludeList(IEnumerable<Expression<Func<T, object>>> includes)
        {
            foreach (var include in includes)
            {
                AddInclude(include);
            }
        }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected void AddCriteria(Expression<Func<T, bool>> criteria)
        {
            Criterias.Add(criteria);
        }

        protected void AddCriteria(IEnumerable<Expression<Func<T, bool>>> criteria)
        {
            Criterias.AddRange(criteria);
        }

        protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression) =>
            OrderBy = orderByExpression;

        protected void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression) =>
            OrderByDescending = orderByDescendingExpression;

        protected void ApplyGroupBy(Expression<Func<T, object>> groupByExpression) =>
            GroupBy = groupByExpression;

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }      
    }
}