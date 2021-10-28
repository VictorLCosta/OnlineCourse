using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Application.Interfaces;
using OnlineCourse.Data.Transactions;
using OnlineCourse.Domain.Entities;
using OnlineCourse.Web.Helpers;

namespace OnlineCourse.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IUow _uow;
        private readonly ICourseService _courseService;

        public CoursesController(IUow uow, ICourseService courseService)
        {
            _uow = uow;
            _courseService = courseService;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course model)
        {
            var result = await _courseService.AddAsync(model);

            return Ok(new { model });
        }
    }
}