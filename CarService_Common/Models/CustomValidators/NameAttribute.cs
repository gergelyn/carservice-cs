using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace CarService_AdminClient.Data.CustomValidators
{
    public class NameAttribute : ValidationAttribute
    {
        Regex nameRgx = new Regex(@"^[A-ZÁÉIÍOÓÖŐUÚÜŰ]+[a-záéiíoóöőuúüű]+$");

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string name = value.ToString();

            if (nameRgx.IsMatch(name))
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
