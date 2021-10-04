using System.Threading.Tasks;
using OnlineCourse.Data.Interfaces;
using OnlineCourse.Data.Repositories;

namespace OnlineCourse.Data.Transactions
{
    public class Uow : IUow
    {
        private readonly ApplicationDbContext _context;

        public ICourseRepository Courses { get; }

        public Uow(ApplicationDbContext context)
        {
            _context = context;

            Courses = new CourseRepository(_context);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await Dispose(true);
        }

        protected virtual async Task Dispose(bool disposing) 
        {
            if(disposing)
            {
                await _context.DisposeAsync();
            }
        }
    }
}