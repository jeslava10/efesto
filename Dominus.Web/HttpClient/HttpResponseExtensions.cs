using Newtonsoft.Json;

namespace Dominus.Web.HttpClient
{
    public static class HttpResponseExtensions
    {
        public static T ContentAsType<T>(this HttpResponseMessage response)
        {
            var data = response.Content.ReadAsStringAsync().Result;
            return string.IsNullOrEmpty(data) ?
                            default(T) :
                            JsonConvert.DeserializeObject<T>(data);
        }
        public static T ContentAsTextType<T>(this HttpResponseMessage response)
        {
            var data = response.Content.ReadAsStringAsync().Result;
            return System.Text.Json.JsonSerializer.Deserialize<T>(data);
        }

        public static string ContentAsJson(this HttpResponseMessage response)
        {
            var data = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.SerializeObject(data);
        }

        public static string ContentAsString(this HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result;
        }
    }

    //public static class HttpResponseExtensions
    //{
    //    public static T ContentAsType<T>(this HttpResponseMessage response)
    //    {
    //        var data = response.Content.ReadAsStringAsync().Result;
    //        return string.IsNullOrEmpty(data) ?
    //                        default(T) :
    //                        JsonSerializer.Deserialize<T>(data);
    //    }

    //    public static string ContentAsJson(this HttpResponseMessage response)
    //    {
    //        var data = response.Content.ReadAsStringAsync().Result;
    //        return JsonSerializer.Serialize(data);
    //    }

    //    public static string ContentAsString(this HttpResponseMessage response)
    //    {
    //        return response.Content.ReadAsStringAsync().Result;
    //    }
    //}
}
