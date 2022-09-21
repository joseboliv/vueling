namespace Utilities.Exception
{
    using FluentValidation.Results;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.Json;

    public class ValidationResultModel
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;
        public string Message { get; set; } = "Validation Failed.";

        public List<ValidationError> Errors { get; set; }


        public ValidationResultModel(ValidationResult validationResult = null)
        {
            Errors = validationResult.Errors
                .Select(error => new ValidationError(error.PropertyName, error.ErrorMessage))
                .ToList();
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
