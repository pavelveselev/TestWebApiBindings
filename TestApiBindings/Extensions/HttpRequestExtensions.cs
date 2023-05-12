using Newtonsoft.Json;
using System.Text;

namespace TestApiBindings.Extensions;

public static class HttpRequestExtensions
{
    public static async Task<object> GetObjectFromRequestBody(this HttpRequest httpRequest, Type type)
    {
        string json;
        using (var reader = new StreamReader(httpRequest.Body, Encoding.UTF8))
            json = await reader.ReadToEndAsync();

        return JsonConvert.DeserializeObject(json, type);
    }
}
