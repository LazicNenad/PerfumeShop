using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PerfumeShop.API.Extensions
{
    public static class ValidationExtensions
    {
        public static UnprocessableEntityObjectResult AsUnprocessableEntity(this IEnumerable<ValidationFailure> errors)
        {
            var errorObj = new
            {
                Errors = errors.Select(x => new
                {
                    PropertyName = x.PropertyName,
                    ErrorMessage = x.ErrorMessage
                })
            };

            return new UnprocessableEntityObjectResult(errorObj);
        }
    }
}
