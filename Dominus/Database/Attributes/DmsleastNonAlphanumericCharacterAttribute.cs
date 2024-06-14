using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Dominus.Database.Attributes
{
    public class DmsleastNonAlphanumericCharacterAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
       ValidationContext validationContext)
        {
            string valueString = Convert.ToString(value);


            var leastNonAlphanumericCharacter = new Regex(@"^(?=.*[!\#$%^&*()-]).{1,}$");

            if (!leastNonAlphanumericCharacter.IsMatch(valueString))
            {
                return new ValidationResult("- One special character (e.g.!@#?-)", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
