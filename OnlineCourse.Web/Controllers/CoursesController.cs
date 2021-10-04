using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Data.Transactions;

namespace OnlineCourse.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IUow _uow;

        public CoursesController(IUow uow)
        {
            _uow = uow;
        }
        
    }
}