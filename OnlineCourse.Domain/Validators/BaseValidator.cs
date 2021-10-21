using System.Collections.Generic;
using System.Linq;
using OnlineCourse.Domain.Models;

namespace OnlineCourse.Domain.Validators
{
    public class RuleValidator
    {
        private readonly List<string> _errorMessages;

        public RuleValidator()
        {
            _errorMessages = new List<string>();
        }

        public static RuleValidator New()
        {
            return new RuleValidator();
        }

        public RuleValidator When(bool condition, string errorMessage)
        {
            if(condition)
                _errorMessages.Add(errorMessage);

            return this;
        }

        public void ThrowExceptionIfExists()
        {
            if(_errorMessages.Any())
                throw new DomainException(_errorMessages);
        }
    }
}