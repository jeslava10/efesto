using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Dominus.Database.Attributes
{
    public class DmsleastOneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
       ValidationContext validationContext)
        {
            string valueString = Convert.ToString(value);


            var leastOneNumber = new Regex(@"^(?=.*\d).{1,}$");

            if (!leastOneNumber.IsMatch(valueString))
            {
                return new ValidationResult("- One number", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
