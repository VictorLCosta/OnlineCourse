using System;
using System.ComponentModel.DataAnnotations;
using ExpectedObjects;
using Xunit;

namespace OnlineCourse.Test
{
    public class FirsTest
    {
        [Fact(DisplayName = "My First Test")]
        public void Test()
        {
            var expectedCourse = new
            {
                Name = "Curso de Cinema",
                Workload = (double)30,
                TargetAudience = TargetAudience.Student,
                Value = (double)590
            };

            var course = new Course(
                expectedCourse.Name, 
                expectedCourse.Workload, 
                expectedCourse.TargetAudience, 
                expectedCourse.Value
            );

            expectedCourse.ToExpectedObject().ShouldMatch(course);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CourseShouldNotHaveAnInvalidName(string invalidName)
        {
            var expectedCourse = new
            {
                Name = invalidName,
                Workload = (double)30,
                TargetAudience = TargetAudience.Student,
                Value = (double)590
            };

            var message = Assert.Throws<ArgumentException>(() => 
                new Course(invalidName, expectedCourse.Workload, expectedCourse.TargetAudience, expectedCourse.Value))
                .Message;

            Assert.Equal("Invalid name", message);
        }

        [Theory(DisplayName = "Course Workload Is Not Less Than 1")]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-200)]
        public void CourseWorkloadMustNotLessThan1(double invalidWorkLoad) {

            var expectedCourse = new
            {
                Name = "Informática básica",
                Workload = invalidWorkLoad,
                TargetAudience = TargetAudience.Student,
                Value = (double)590
            };

            var message = Assert.Throws<ArgumentException>(() => 
                new Course(expectedCourse.Name, expectedCourse.Workload, expectedCourse.TargetAudience, expectedCourse.Value))
                .Message;

            Assert.Equal("Invalid workload", message);
        }

        [Theory(DisplayName = "Course Value Is Not Less Than 1")]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-200)]
        public void CourseValueMustNotLessThan1(double value) {

            var expectedCourse = new
            {
                Name = "Informática básica",
                Workload = (double)50,
                TargetAudience = TargetAudience.Student,
                Value = value
            };

            var message = Assert.Throws<ArgumentException>(() => 
                new Course(expectedCourse.Name, expectedCourse.Workload, expectedCourse.TargetAudience, expectedCourse.Value))
                .Message;

            Assert.Equal("Invalid value", message);
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
        public Course(string name, double workload, TargetAudience targetAudience, double value)
        {
            if(String.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid name");

            if(workload < 1)
                throw new ArgumentException("Invalid workload");

            if(value < 1)
                throw new ArgumentException("Invalid value");

            Name = name;
            Workload = workload;
            TargetAudience = targetAudience;
            Value = value;
        }

        public string Name { get; set; }
        public double Workload { get; set; }
        public TargetAudience TargetAudience { get; set; }
        public double Value { get; set; }
    }
}