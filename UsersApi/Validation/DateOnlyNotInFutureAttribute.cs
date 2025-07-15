using System.ComponentModel.DataAnnotations;
using UsersApi.Extensions;

namespace UsersApi.Validation;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class DateOnlyNotInFutureAttribute() : ValidationAttribute("The field {0} cannot be in the future.")
{
    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value is null || (value is DateOnly date && date.IsNotInFuture())) return ValidationResult.Success;

        return new ValidationResult(FormatErrorMessage(context.DisplayName));
    }
}