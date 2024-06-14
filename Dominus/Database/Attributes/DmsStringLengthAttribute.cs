using Dominus.Application;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Dominus.Database.Attributes
{
    public class DmsStringLengthAttribute : StringLengthAttribute
    {
        private readonly string _callerPropertyName;

        public string ResourceKey { get; set; }

        public DmsStringLengthAttribute(string resourceKey, int maximumLength, [CallerMemberName] string propertyName = null)
            : base(maximumLength)
        {
            ResourceKey = resourceKey;
            _callerPropertyName = propertyName;
            ErrorMessage = Localization.GetResource(resourceKey) + "("+ maximumLength + ")";//, MaximumLength);
        }

        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
    }
}

