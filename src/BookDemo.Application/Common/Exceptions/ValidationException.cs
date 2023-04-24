using System;
using System.Collections.Generic;
using System.Linq;

using FluentValidation.Results;

namespace BookDemo.Application.Common.Exceptions
{
   public class ValidationException : Exception
   {
      public ValidationException() : base("One or more validation failures have occurred.")
      {
      }

      public ValidationException(string? message) : base(message)
      {
      }

      public ValidationException(string? message, Exception? innerException) : base(message, innerException)
      {
      }

      public ValidationException(IEnumerable<ValidationFailure> failures)
          : this()
      {
         Errors = failures
             .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
             .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
      }

      public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();
   }
}