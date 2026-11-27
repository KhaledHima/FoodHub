using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FoodHub.Binders
{
    public class FlexibleDecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            var type = context.Metadata.UnderlyingOrModelType;
            return type == typeof(decimal) ? new FlexibleDecimalModelBinder() : null;
        }
    }
}
