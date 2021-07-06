using FluentValidation.Results;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Extensions
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ValidationErrorDetais : ErrorDetails
    {
        public IEnumerable<ValidationFailure> ValidationsErrors { get; set; }
    }
}
