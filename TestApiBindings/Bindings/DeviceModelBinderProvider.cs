using Microsoft.AspNetCore.Mvc.ModelBinding;
using TestApiBindings.Models;

namespace TestApiBindings.Bindings;

public class DeviceModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType != typeof(Device))
        {
            return null;
        }

        return new DeviceModelBinder();
    }
}
