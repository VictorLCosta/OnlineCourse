using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Application.Interfaces;
using OnlineCourse.Application.Validators;
using OnlineCourse.Data.Transactions;
using OnlineCourse.Domain.Entities;

namespace OnlineCourse.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUow _unitOfWork;

        public CourseService(IUow unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> AddAsync(Course model)
        {
            BaseValidator.New()
                .When(String.IsNullOrWhiteSpace(model.Description), "Por favor, insira uma descrição")
                .When(model.Value < 1, "Por favor, insira um valor maior do que 1")
                .When(model.Workload < 1, "Por favor, insira uma carga horário válida")
                .ThrownExceptionIfExists();

            await _unitOfWork.Courses.Add(model);
            return new OkObjectResult(new { success = true, message = "Curso inserdo com sucesso" });
        }
    }
}
