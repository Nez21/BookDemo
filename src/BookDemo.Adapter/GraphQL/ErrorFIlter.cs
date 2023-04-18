using System;
using System.Collections.Generic;
using BookDemo.Application.Common.Exceptions;
using HotChocolate;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ValidationException = BookDemo.Application.Common.Exceptions.ValidationException;

public class ErrorFilter : IErrorFilter
{
   private readonly ILogger _logger;

   public ErrorFilter(ILogger<ErrorFilter> logger)
   {
      _logger = logger;
   }

   public IError OnError(IError error)
   {
      if (error.Exception is ValidationException validationException)
      {
         return error.WithMessage(validationException.Message)
            .WithCode("VALIDATION_ERROR")
            .SetExtension("errors", JsonConvert.SerializeObject(validationException.Errors));
      }


      if (error.Exception is NotFoundException notFoundException)
      {
         return error.WithMessage(notFoundException.Message)
            .WithCode("NOT_FOUND");
      }

      if (error.Exception is Exception exception)
      {
         _logger.LogError(exception, exception.Message);
      }

      return error;
   }
}