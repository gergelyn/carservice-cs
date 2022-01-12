using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace CarService_Common.Models.CustomValidators
{
    public class LicensePlateAttribute : ValidationAttribute
    {
        Regex licensePlateRgx = new Regex(@"^[A-Z]{3}-[0-9]{3}$");

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string licensePlateStr = value.ToString();

            if (licensePlateRgx.IsMatch(licensePlateStr))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
            
        }
    }
}
