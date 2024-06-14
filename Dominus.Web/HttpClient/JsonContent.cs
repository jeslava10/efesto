using Newtonsoft.Json;
using System.Text;

namespace Dominus.Web.HttpClient
{
    public class JsonContent : StringContent
    {

        public JsonContent(object value)
            : base(JsonConvert.SerializeObject(value,JsonSettings.GetJsonSettings()), Encoding.UTF8, "application/json")
        {
        }

        public JsonContent(object value, string mediaType)
            : base(JsonConvert.SerializeObject(value,JsonSettings.GetJsonSettings()), Encoding.UTF8, mediaType)
        {
        }

        public JsonContent(object value, JsonSerializerSettings settings)
            : base(JsonConvert.SerializeObject(value, settings), Encoding.UTF8, "application/json")
        {
        }


        //public JsonContent(object value)
        //    : base(JsonSerializer.Serialize(value,JsonSettings.GetJsonSettings()), Encoding.UTF8, "application/json")
        //{
        //}

        //public JsonContent(object value, string mediaType)
        //    : base(JsonSerializer.Serialize(value), Encoding.UTF8, mediaType)
        //{
        //}

        //public JsonContent(object value, JsonSerializerOptions settings)
        //    : base(JsonSerializer.Serialize(value, settings), Encoding.UTF8, "application/json")
        //{
        //}

        //public JsonContent(object value, string mediaType)
        //    : base(JsonConvert.SerializeObject(value, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects }), Encoding.UTF8, mediaType)
        //{
        //}
    }

    public static class JsonSettings
    {
        public static JsonSerializerSettings GetJsonSettings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            settings.NullValueHandling = NullValueHandling.Ignore;
            //settings.TypeNameHandling = TypeNameHandling.Objects; //Esto hace que se agregue la propriedad $type Si esta configurado como ".Object" a las respuestas JSON
            //options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects; // Esto hace que se agregue la propiedad $id a las respuestas JSON
            //settings.ContractResolver = new DefaultContractResolver(); //Esto hace que las propiedades de las respuestas JSON se conviertan en CamelCase 
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            settings.DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
            settings.DateFormatString = "yyyy-MM-ddTHH:mm:ss.fff";
            return settings;
        }

        //public static JsonSerializerOptions GetJsonSettings()
        //{
        //    JsonSerializerOptions settings = new JsonSerializerOptions();
        //    settings.PropertyNameCaseInsensitive = true;
        //    settings.PropertyNamingPolicy = null;
        //    settings.AllowTrailingCommas = true;
        //    settings.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        //    return settings;
        //}
    }
}
