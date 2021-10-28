using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourse.Application.Interfaces;
using OnlineCourse.Application.Services;
using OnlineCourse.Application.Validators;

namespace OnlineCourse.Web.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<ICourseService, CourseService>();

            services.AddTransient<BaseValidator, BaseValidator>();

            return services;
        }
    }
}
