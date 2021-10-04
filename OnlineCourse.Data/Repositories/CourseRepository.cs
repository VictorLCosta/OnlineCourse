using OnlineCourse.Data.Interfaces;
using OnlineCourse.Domain.Entities;

namespace OnlineCourse.Data.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            
        }
    }
}