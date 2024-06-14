using System.ComponentModel;
using System.Runtime.CompilerServices;
using Dominus.Application;

namespace Dominus.Database.Attributes
{
    public class DmsDisplayNameAttribute : DisplayNameAttribute
    {
        private readonly string _callerPropertyName;

        private string ResourceKey { get; set; }


        public DmsDisplayNameAttribute(string resourceKey, [CallerMemberName] string propertyName = null)
            : base(resourceKey)
        {
            ResourceKey = resourceKey;
            _callerPropertyName = propertyName;
        }

        public override string DisplayName
        {
            get
            {
                string value = null;
                value = Localization.GetResource(ResourceKey);

                if (string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(_callerPropertyName))
                {
                    value = _callerPropertyName;
                }

                return value;
            }
        }

        public string Name
        {
            get { return "ResourceDisplayName"; }
        }
    }
}
