using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Incidents.DAL.CustomAttributes
{
    public class ValidateCountGreaterThanZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var list = value as IList;

            if (list != null && list.Count == 0)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}

