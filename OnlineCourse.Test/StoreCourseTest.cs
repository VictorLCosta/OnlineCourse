using System;
using Moq;
using OnlineCourse.Domain.Entities;
using OnlineCourse.Domain.Enums;
using Xunit;

namespace OnlineCourse.Test
{
    public class StoreCourseTest
    {
        [Fact]
        public void MustAddCourse() 
        {
            var dtoCourse = new DtoCourse 
            {
                Name = "Zaratos",
                Description = "O mago",
                Workload = 500.00,
                TargetAudienceId = 1,
                Value = 850.00
            };

            var courseRepositoryMock = new Mock<ICourseRepository>();
            var courseService = new CourseService(courseRepositoryMock.Object);

            courseService.Add(dtoCourse);

            courseRepositoryMock.Verify(x => x.Add(It.IsAny<Course>()));
        }
    }

    public interface ICourseRepository
    {
        void Add(Course Course);
    }

    public class CourseService 
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void Add(DtoCourse dtoCourse)
        {
            var course = new Course(
                dtoCourse.Name, 
                dtoCourse.Description, 
                dtoCourse.Workload, 
                TargetAudience.Student, 
                dtoCourse.Value
            );

            _courseRepository.Add(course);
        }
    }

    public class DtoCourse 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Workload { get; set; }
        public int TargetAudienceId { get; set; }
        public double Value { get; set; }
    }
}