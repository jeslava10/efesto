using System.Text;
using System.Text.Json;

namespace Dominus.Web.HttpClient
{
    public class PatchContent : StringContent
    {
        public PatchContent(object value)
            : base (JsonSerializer.Serialize(value), Encoding.UTF8, "application/json-patch+json")
        {
        }
    }
}
