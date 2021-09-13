using Xunit;

namespace OnlineCourse.Test
{
    public class FirsTest
    {
        [Fact(DisplayName = "My First Test")]
        public void Test()
        {
            var name = "Curso de Cinema";
            var workload = 80;
            var target = "Estudantes";
            var value = 950;

            var course = new Course(name, workload, target, value);

            Assert.Equal(name, course.Name);
            Assert.Equal(workload, course.Workload);
            Assert.Equal(target, course.TargetAudience);
            Assert.Equal(value, course.Value);
        }   
    }

    public class Course
    {
        public Course(string name, double workload, string targetAudience, double value)
        {
            Name = name;
            Workload = workload;
            TargetAudience = targetAudience;
            Value = value;
        }

        public string Name { get; set; }
        public double Workload { get; set; }
        public string TargetAudience { get; set; }
        public double Value { get; set; }
    }
}