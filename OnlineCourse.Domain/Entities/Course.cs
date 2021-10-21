using System;
using OnlineCourse.Domain.Enums;
using OnlineCourse.Domain.Validators;

namespace OnlineCourse.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Workload { get; set; }
        public TargetAudience TargetAudience { get; private set; }
        public double Value { get; private set; }

        public Course()
        {
        }

        public Course(string name, string description, double workload, TargetAudience targetAudience, double value)
        {
            RuleValidator.New()
                .When(string.IsNullOrEmpty(name), "Nome inválido")
                .When(workload < 1, "Carga horária inválida")
                .When(value < 1, "Valor inválido")
                .ThrowExceptionIfExists();

            Name = name;
            Description = description;
            Workload = workload;
            TargetAudience = targetAudience;
            Value = value;
        }

    }
    
}