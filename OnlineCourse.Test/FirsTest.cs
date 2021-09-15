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