using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FoodHub.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public partial class EgyptianPhoneAttribute : ValidationAttribute
    {
        [GeneratedRegex(@"^01[0125]\d{8}$")]
        private static partial Regex PhoneRegex();

        public EgyptianPhoneAttribute()
            : base("{0} must be a valid Egyptian mobile number (e.g. 01012345678).")
        {
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string phone || string.IsNullOrWhiteSpace(phone))
            {
                return ValidationResult.Success;
            }

            var digits = phone.Replace(" ", "").Replace("-", "");
            return PhoneRegex().IsMatch(digits)
                ? ValidationResult.Success
                : new ValidationResult(FormatErrorMessage(validationContext.DisplayName), [validationContext.MemberName!]);
        }
    }
}
