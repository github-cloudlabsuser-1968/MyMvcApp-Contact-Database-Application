using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyMvcApp.Attributes
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        private readonly string _emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Email is required");

            string email = value.ToString();
            if (!Regex.IsMatch(email, _emailPattern))
                return new ValidationResult("Invalid email format");

            return ValidationResult.Success;
        }
    }
}