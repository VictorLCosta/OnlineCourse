using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineCourse.Data.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Queryable();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}