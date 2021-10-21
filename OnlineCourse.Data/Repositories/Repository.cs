using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OnlineCourse.Data.Interfaces;

namespace OnlineCourse.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set<T>().Where(predicate).AsQueryable();
            return query;
        }

        public IQueryable<T> Queryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}