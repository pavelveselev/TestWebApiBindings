using Microsoft.AspNetCore.Mvc.ModelBinding;
using TestApiBindings.Extensions;
using TestApiBindings.Models;

namespace TestApiBindings.Bindings;

public class DeviceModelBinder : IModelBinder
{
    private readonly Type[] _modelSubclasses;

    public DeviceModelBinder(Type[] modelSubclasses)
    {
        _modelSubclasses = modelSubclasses;
    }

    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var modelTypeValue = bindingContext.ValueProvider.GetValue("kind").FirstValue;
        var type = _modelSubclasses.FirstOrDefault(s => s.Name.Equals(modelTypeValue, StringComparison.InvariantCultureIgnoreCase));

        bindingContext.Result = type != null && type.IsSubclassOf(typeof(Device))
            ? ModelBindingResult.Success(await bindingContext.ActionContext.HttpContext.Request.GetObjectFromRequestBody(type))
            : ModelBindingResult.Failed();
    }
}
