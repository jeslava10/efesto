using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Dominus.Database.Attributes
{
    public class DmsPasswordValidateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
        ValidationContext validationContext)
        {
            string valueString = Convert.ToString(value);
            if (valueString.Length < 8)
            {
                return new ValidationResult("Password must have at least:", new[] { validationContext.MemberName });
            }

            var leastOneUpperCaseLetter = new Regex(@"^(?=.*[A-Z])+(?=.*[a-z]).{1,}$");

            if (!leastOneUpperCaseLetter.IsMatch(valueString))
            {
                return new ValidationResult("Password must have at least:", new[] { validationContext.MemberName });
            }

            var leastNonAlphanumericCharacter = new Regex(@"^(?=.*[!\#$%^&*()-]).{1,}$");

            if (!leastNonAlphanumericCharacter.IsMatch(valueString))
            {
                return new ValidationResult("Password must have at least:", new[] { validationContext.MemberName });
            }

            var leastOneNumber = new Regex(@"^(?=.*\d).{1,}$");

            if (!leastOneNumber.IsMatch(valueString))
            {
                return new ValidationResult("Password must have at least:", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
