using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Dominus.Database.Attributes
{
    public class DmsleastOneUpperCaseLetterAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
      ValidationContext validationContext)
        {
            string valueString = Convert.ToString(value);


            var leastOneUpperCaseLetter = new Regex(@"^(?=.*[A-Z])+(?=.*[a-z]).{1,}$");

            if (!leastOneUpperCaseLetter.IsMatch(valueString))
            {
                return new ValidationResult("- Uppercase and lowercase letters ", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}