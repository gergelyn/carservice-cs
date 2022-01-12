using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace CarService_AdminClient.Data.CustomValidators
{
    public class CarTypeAttribute : ValidationAttribute
    {
        Regex carTypeRgx = new Regex(@"^[A-ZÁÉIÍOÓÖŐUÚÜŰ]+[a-záéiíoóöőuúüű]*(\s[A-ZÁÉIÍOÓÖŐUÚÜŰ]+[a-záéiíoóöőuúüű]*)*$");

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string carTypeStr = value.ToString();

            if (carTypeRgx.IsMatch(carTypeStr))
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
