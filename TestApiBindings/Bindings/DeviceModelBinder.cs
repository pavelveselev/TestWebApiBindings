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

        Device model1;
        if (modelTypeValue == "Laptop")
        {
            string json;
            using (var reader = new StreamReader(bindingContext.ActionContext.HttpContext.Request.Body, Encoding.UTF8))
                json = await reader.ReadToEndAsync();

            var model2 = JsonConvert.DeserializeObject<Laptop>(json);

            model1 = model2;
        }
        else if (modelTypeValue == "SmartPhone")
        {
            string json;
            using (var reader = new StreamReader(bindingContext.ActionContext.HttpContext.Request.Body, Encoding.UTF8))
                json = await reader.ReadToEndAsync();

            var model2 = JsonConvert.DeserializeObject<SmartPhone>(json);

            model1 = model2;
        }
        else
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return;
        }

        bindingContext.Result = ModelBindingResult.Success(model1);
    }
}
