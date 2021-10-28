using System;
using OnlineCourse.Domain.Enums;

namespace OnlineCourse.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Workload { get; set; }
        public TargetAudience TargetAudience { get; set; }
        public double Value { get; set; }        

    }
    
}