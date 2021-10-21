using System;
using System.Collections.Generic;

namespace OnlineCourse.Domain.Models
{
    public class DomainException : ArgumentException
    {
        public List<string> ErrorMessages { get; set; }

        public DomainException(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}