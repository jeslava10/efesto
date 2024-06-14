using Dominus.Application;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Dominus.Database.Attributes
{
    public  class DmsRequiredAttribute : RequiredAttribute
    {
        private readonly string _callerPropertyName;

        public string ResourceKey { get; set; }

        public DmsRequiredAttribute(string resourceKey, [CallerMemberName] string propertyName = null)
            : base()
        {
            ResourceKey = resourceKey;
            _callerPropertyName = propertyName;
            ErrorMessage = Localization.GetResource(resourceKey);
        }

        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
    }
}
