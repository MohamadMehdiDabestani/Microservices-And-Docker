using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Exception
{
    class ValidationException : ApplicationException
    {
        public ValidationException() : base("one or more validation failures have occurred")
        {
            
        }
        public ValidationException(IEnumerable<ValidationFailure> failures)
        {
            Error = failures.GroupBy(f => f.PropertyName, f => f.ErrorMessage).ToDictionary(e => e.Key, e => e.ToArray());
        }
        public Dictionary<string , string[]> Error { get; }
    }
}
