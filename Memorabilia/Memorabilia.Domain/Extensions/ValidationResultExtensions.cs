namespace Memorabilia.Domain.Extensions;

public static class ValidationResultExtensions
{
    public static bool HasErrors(this ValidationResult validationResult)
        => validationResult.Errors != null && validationResult.Errors.Count != 0;
}
