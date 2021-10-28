using System;
using System.Collections.Generic;

namespace OnlineCourse.Application.Models.Exceptions
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