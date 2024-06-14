using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Dominus.Database.Attributes
{
    public  class DmsleastOneLowerCaseLetterAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
       ValidationContext validationContext)
        {
            string valueString = Convert.ToString(value);

            var leastOneLowerCaseLetter = new Regex(@"^(?=.*[a-z]).{1,}$");

            if (!leastOneLowerCaseLetter.IsMatch(valueString))
            {
                return new ValidationResult("- Lowercase letters ", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
