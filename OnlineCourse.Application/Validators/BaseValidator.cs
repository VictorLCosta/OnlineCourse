using System.Collections.Generic;
using System.Linq;
using OnlineCourse.Application.Models.Exceptions;

namespace OnlineCourse.Application.Validators
{
    public class BaseValidator
    {
        public List<string> ErrorMessages { get; set; }

        public BaseValidator()
        {
            ErrorMessages = new List<string>();
        }

        public static BaseValidator New()
        {
            return new BaseValidator();
        }

        public BaseValidator When(bool condition, string errorMessage)
        {
            if(condition) 
            {
                ErrorMessages.Add(errorMessage);
            }

            return this;
        }

        public void ThrownExceptionIfExists()
        {
            if(ErrorMessages.Any()) 
            {
                throw new DomainException(ErrorMessages);
            }
        }
    }
}
