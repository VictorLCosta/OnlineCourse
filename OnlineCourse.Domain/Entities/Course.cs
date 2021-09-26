using System;
using OnlineCourse.Domain.Enums;

namespace OnlineCourse.Domain.Entities
{
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

        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Workload { get; set; }
        public TargetAudience TargetAudience { get; private set; }
        public double Value { get; private set; }
    }
    
}