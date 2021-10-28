using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Domain.Entities;

namespace OnlineCourse.Application.Interfaces
{
    public interface ICourseService
    {
        Task<IActionResult> AddAsync(Course model);
    }
}
