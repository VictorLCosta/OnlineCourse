using System;
using Bogus;
using ExpectedObjects;
using OnlineCourse.Test.Builders;
using OnlineCourse.Test.Utils;
using Xunit;
using Xunit.Abstractions;

namespace OnlineCourse.Test
{
    public class CouseTest : IDisposable
    {
        private readonly ITestOutputHelper _output;

        private readonly string _name;
        private readonly string _description;
        private readonly double _workload;
        private readonly TargetAudience _targetAudience;
        private readonly double _value;

        public CouseTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Construtor executado");

            var faker = new Faker();

            _name = faker.Random.Word();
            _description = faker.Lorem.Paragraph();
            _workload = faker.Random.Double(50, 1000);
            _targetAudience = TargetAudience.Student;
            _value = faker.Random.Double(100, 1000);
        }

        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executado");
        }

        [Fact(DisplayName = "My First Test")]
        public void Test()
        {
            var expectedCourse = new
            {
                Name = _name,
                Description = _description,
                Workload = _workload,
                TargetAudience = _targetAudience,
                Value = _value
            };

            var course = CourseBuilder.New()
                .WithName(expectedCourse.Name)
                .WithDescription(expectedCourse.Description)
                .WithWorkload(expectedCourse.Workload)
                .WithTargetAudience(expectedCourse.TargetAudience)
                .WithValue(expectedCourse.Value)
                .Build();

            expectedCourse.ToExpectedObject().ShouldMatch(course);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CourseShouldNotHaveAnInvalidName(string invalidName)
        {
            Assert.Throws<ArgumentException>(() => 
                CourseBuilder.New().WithName(invalidName).Build())
                .WithMessage("Invalid name");
        }

        [Theory(DisplayName = "Course Workload Is Not Less Than 1")]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-200)]
        public void CourseWorkloadMustNotLessThan1(double invalidWorkLoad) 
        {
            Assert.Throws<ArgumentException>(() => 
                CourseBuilder.New().WithWorkload(invalidWorkLoad).Build())
                .WithMessage("Invalid workload");
        }

        [Theory(DisplayName = "Course Value Is Not Less Than 1")]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-200)]
        public void CourseValueMustNotLessThan1(double value) 
        {
            Assert.Throws<ArgumentException>(() => 
                CourseBuilder.New().WithValue(value).Build())
                .WithMessage("Invalid value");
        }

    }

    public enum TargetAudience : int
    {
        Student = 1,
        Academic,
        Employee,
        Entrepreneur
    }

    public class Course
    {
        public Course(string name, string description, double workload, TargetAudience targetAudience, double value)
        {
            if(String.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid name");

            if(workload < 1)
                throw new ArgumentException("Invalid workload");

            if(value < 1)
                throw new ArgumentException("Invalid value");

            Name = name;
            Description = description;
            Workload = workload;
            TargetAudience = targetAudience;
            Value = value;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Workload { get; set; }
        public TargetAudience TargetAudience { get; set; }
        public double Value { get; set; }
    }
}