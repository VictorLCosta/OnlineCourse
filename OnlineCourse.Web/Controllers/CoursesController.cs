using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Data.Transactions;
using OnlineCourse.Domain.Entities;
using OnlineCourse.Web.Helpers;

namespace OnlineCourse.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IUow _uow;

        public CoursesController(IUow uow)
        {
            _uow = uow;
        }
        
        public async Task<IActionResult> Index()
        {
            var courses = _uow.Courses.Queryable();
            var pagedCourses = await PagedList<Course>.CreateAsync(courses, 1, 5);

            return View(pagedCourses);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Course model)
        {
            var course = new Course(
                model.Name,
                model.Description,
                model.Workload,
                model.TargetAudience,
                model.Value
            );

            await _uow.Courses.Add(course);
            return Ok();
        }
    }
}