using Contracts;
using System.Linq.Expressions;

namespace DotaMarket.DataLayer.Specification
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        protected BaseSpecification()
        {

        }
        public Expression<Func<T, bool>> Criteria { get; private set; }
        
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; private set; }
       
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public int Take { get; private set; }
       
        public int Skip { get; private set; }
      
        public bool IsPagingEnabled { get; private set; }

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected virtual void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected void AddCriteria(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        protected virtual void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}