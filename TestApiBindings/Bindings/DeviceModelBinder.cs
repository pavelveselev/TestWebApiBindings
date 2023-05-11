using Microsoft.AspNetCore.Mvc.ModelBinding;
using TestApiBindings.Models;
using System.Text;
using Newtonsoft.Json;

namespace TestApiBindings.Bindings;

public class DeviceModelBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var modelTypeValue = bindingContext.ValueProvider.GetValue("kind").FirstValue;

        Device model;
        if (modelTypeValue == "Laptop")
        {
            model = await GetObjectFromRequestBody<Laptop>(bindingContext.ActionContext.HttpContext);
        }
        else if (modelTypeValue == "SmartPhone")
        {
            model = await GetObjectFromRequestBody<SmartPhone>(bindingContext.ActionContext.HttpContext);
        }
        else
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return;
        }

        bindingContext.Result = ModelBindingResult.Success(model);
    }

    private static async Task<T> GetObjectFromRequestBody<T>(HttpContext httpContext)
    {
        string json;
        using (var reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8))
            json = await reader.ReadToEndAsync();

        return JsonConvert.DeserializeObject<T>(json);
    }
}
