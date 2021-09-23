namespace OnlineCourse.Test.Builders
{
    public class CourseBuilder
    {
        private string _name = "Informática Básica";
        private double _workload = 50;
        private TargetAudience _targetAudience = TargetAudience.Student;
        private double _value = 120;
        private string _description = "Aulas de Office";

        public static CourseBuilder New()
        {
            return new CourseBuilder();
        }

        public CourseBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        
        public CourseBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public CourseBuilder WithWorkload(double workload)
        {
            _workload = workload;
            return this;
        }

        public CourseBuilder WithTargetAudience(TargetAudience targetAudience)
        {
            _targetAudience = targetAudience;
            return this;
        }

        public CourseBuilder WithValue(double value)
        {
            _value = value;
            return this;
        }


        public Course Build()
        {
            return new Course(_name, _description, _workload, _targetAudience, _value);
        }
    }
}