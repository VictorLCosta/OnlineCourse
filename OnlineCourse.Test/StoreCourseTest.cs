using System;
using Bogus;
using Moq;
using OnlineCourse.Domain.Entities;
using OnlineCourse.Domain.Enums;
using OnlineCourse.Test.Utils;
using Xunit;

namespace OnlineCourse.Test
{
    public class StoreCourseTest
    {
        private DtoCourse _dtoCourse;
        private Mock<ICourseRepository> _courseRepositoryMock;
        private CourseService _courseService;

        public StoreCourseTest()
        {
            var faker = new Faker();

            _dtoCourse = new DtoCourse 
            {
                Name = faker.Person.FullName,
                Description = faker.Lorem.Paragraph(),
                Workload = faker.Random.Double(50, 100),
                TargetAudience = "Student",
                Value = faker.Random.Double(100, 600)
            };

            _courseRepositoryMock = new Mock<ICourseRepository>();
            _courseService = new CourseService(_courseRepositoryMock.Object);
        }

        [Fact]
        public void MustAddCourse() 
        {
            _courseService.Add(_dtoCourse);

            _courseRepositoryMock.Verify(x => x.Add(It.Is<Course>(
                x => x.Name == _dtoCourse.Name &&
                x.Description == _dtoCourse.Description 
            )));
        }

        [Fact]
        public void MustNotInformInvalidTargetAudience()
        {
            _dtoCourse.TargetAudience = "Médico";

            Assert.Throws<ArgumentException>(() => _courseService.Add(_dtoCourse))
                .WithMessage("Invalid target audience");
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
            if(!Enum.TryParse<TargetAudience>(dtoCourse.TargetAudience, out var targetAudience))
                throw new ArgumentException("Invalid target audience");

            var course = new Course() 
            {
                Name = dtoCourse.Name, 
                Description = dtoCourse.Description, 
                Workload = dtoCourse.Workload, 
                TargetAudience = (TargetAudience)targetAudience, 
                Value = dtoCourse.Value
            };

            _courseRepository.Add(course);
        }
    }

    public class DtoCourse 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Workload { get; set; }
        public string TargetAudience { get; set; }
        public double Value { get; set; }
    }
}