namespace Utilities.Exception
{
    using System;

    public class ValidationException : Exception
    {
        public ValidationException(ValidationResultModel validationResultModel)
        {
            ValidationResultModel = validationResultModel;
        }

        public ValidationResultModel ValidationResultModel { get; }
    }
}
