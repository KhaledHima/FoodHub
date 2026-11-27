using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FoodHub.Binders
{
    public class FlexibleDecimalModelBinder : IModelBinder
    {
        private static readonly string[] Suffixes = ["EGP", "LE", "ج.م", "جنيه"];

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueResult);
            var raw = valueResult.FirstValue;

            if (string.IsNullOrWhiteSpace(raw))
            {
                if (bindingContext.ModelMetadata.IsReferenceOrNullableType)
                {
                    bindingContext.Result = ModelBindingResult.Success(null);
                }
                else
                {
                    bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, $"{bindingContext.ModelMetadata.GetDisplayName()} is required.");
                }

                return Task.CompletedTask;
            }

            if (decimal.TryParse(Normalize(raw), NumberStyles.Number, CultureInfo.InvariantCulture, out var value))
            {
                bindingContext.Result = ModelBindingResult.Success(value);
            }
            else
            {
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, $"'{raw}' is not a valid amount.");
            }

            return Task.CompletedTask;
        }

        public static string Normalize(string raw)
        {
            var text = raw.Trim();
            foreach (var suffix in Suffixes)
            {
                text = text.Replace(suffix, "", StringComparison.OrdinalIgnoreCase);
            }

            var normalized = new StringBuilder(text.Length);
            foreach (var character in text)
            {
                if (character is >= '٠' and <= '٩') normalized.Append((char)('0' + (character - '٠')));
                else if (character is >= '۰' and <= '۹') normalized.Append((char)('0' + (character - '۰')));
                else if (character == '٫') normalized.Append('.');
                else if (character is >= '0' and <= '9' or '.' or '-') normalized.Append(character);
            }

            return normalized.ToString();
        }
    }
}
