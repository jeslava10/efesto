using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Dominus.Web.HttpClient
{
    public enum PostContentType
    {
        TextPlain,
        ApplicationX_www_form_urlencoded
    }
    public static class HttpRequestFactory
    {
        public static async Task<HttpResponseMessage> Get(string requestUri)
            => await Get(requestUri, "");

        public static async Task<HttpResponseMessage> Get(string requestUri, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Get)
                                .AddRequestUri(requestUri)
                                .AddBearerToken(bearerToken);
            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Get(string requestUri, object value)
            => await Get(requestUri, "");

        public static async Task<HttpResponseMessage> Get(string requestUri, object value, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Get)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddBearerToken(bearerToken);
            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Post(string requestUri, object value)
            => await Post(requestUri, value, "");

        public static async Task<HttpResponseMessage> Post(string requestUri, object value, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                 .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> PostExpression(string requestUri, object value, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        //public static async Task<HttpResponseMessage> PostExpression(string requestUri, object value, string bearerToken)
        //{
        //    var builder = new HttpRequestBuilder()
        //                        .AddMethod(HttpMethod.Post)
        //                        .AddRequestUri(requestUri)
        //                        .AddContent(new JsonContent(value))
        //                        .AddBearerToken(bearerToken);

        //    return await builder.SendAsync();
        //}

        public static async Task<HttpResponseMessage> PostExpression(string requestUri, object value, string bearerToken, JsonSerializerSettings settings)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                //.AddContent(new JsonContent(value, settings))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        //public static async Task<HttpResponseMessage> PostExpression(string requestUri, object value, string bearerToken, JsonSerializerOptions settings)
        //{
        //    var builder = new HttpRequestBuilder()
        //                        .AddMethod(HttpMethod.Post)
        //                        .AddRequestUri(requestUri)
        //                        .AddContent(new JsonContent(value, settings))
        //                        .AddBearerToken(bearerToken);

        //    return await builder.SendAsync();
        //}

        public static async Task<HttpResponseMessage> Put(string requestUri, object value)
            => await Put(requestUri, value, "");

        public static async Task<HttpResponseMessage> Put(
            string requestUri, object value, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Put)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Patch(string requestUri, object value)
            => await Patch(requestUri, value, "");

        public static async Task<HttpResponseMessage> Patch(
            string requestUri, object value, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(new HttpMethod("PATCH"))
                                .AddRequestUri(requestUri)
                                .AddContent(new PatchContent(value))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Delete(string requestUri)
            => await Delete(requestUri, "");

        public static async Task<HttpResponseMessage> Delete(
            string requestUri, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Delete)
                                .AddRequestUri(requestUri)
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> DeleteExpression(string requestUri, object value, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Delete)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        //public static async Task<HttpResponseMessage> DeleteExpression(string requestUri, object value, string bearerToken)
        //{
        //    var builder = new HttpRequestBuilder()
        //                        .AddMethod(HttpMethod.Delete)
        //                        .AddRequestUri(requestUri)
        //                        .AddContent(new JsonContent(value, new JsonSerializerOptions()))
        //                        .AddBearerToken(bearerToken);

        //    return await builder.SendAsync();
        //}

        public static async Task<HttpResponseMessage> PostFile(string requestUri,
            string filePath, string apiParamName)
            => await PostFile(requestUri, filePath, apiParamName, "");

        public static async Task<HttpResponseMessage> PostFile(string requestUri,
            string filePath, string apiParamName, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddContent(new FileContent(filePath, apiParamName))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }


        public static async Task<HttpResponseMessage> Post(string requestUri, object value, PostContentType contentType = PostContentType.TextPlain)
            => await Post(requestUri, value, "", contentType);

        public static async Task<HttpResponseMessage> Post(
            string requestUri, object value, string bearerToken, PostContentType contentType = PostContentType.TextPlain)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddBearerToken(bearerToken);

            if (contentType == PostContentType.ApplicationX_www_form_urlencoded)
            {
                IEnumerable<KeyValuePair<string, string>> enumerableKeyValuePair = (IEnumerable<KeyValuePair<string, string>>)value;
                builder.AddContent(new FormUrlEncodedContent(enumerableKeyValuePair));
            }
            else
            {
                builder.AddContent(new JsonContent(value));
            }

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> PostXWwwFormUrlencoded(string requestUri, IEnumerable<KeyValuePair<string, string>> value)
            => await Post(requestUri, value, "", PostContentType.ApplicationX_www_form_urlencoded);

        public static async Task<HttpResponseMessage> PostXWwwFormUrlencoded(string requestUri, IEnumerable<KeyValuePair<string, string>> value, string bearerToken)
            => await Post(requestUri, value, bearerToken, PostContentType.ApplicationX_www_form_urlencoded);
    }
}
