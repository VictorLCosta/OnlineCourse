using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineCourse.Application.Models.Exceptions;

namespace OnlineCourse.Web.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            bool isAjaxCall = context.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";

            if(isAjaxCall)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = context.Exception is DomainException ? 500 : 502;
                context.Result = context.Exception is DomainException domain ? 
                    new JsonResult(domain.ErrorMessages) : 
                    new JsonResult("An error ocurred") ;
                context.ExceptionHandled = true;
            }

            base.OnException(context);
        }
    }
}