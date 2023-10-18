namespace Memorabilia.Domain.Command;

public abstract class DomainCommand : IDomainCommand
{
    public bool IsValid 
        => ValidationResult != null && 
           ValidationResult.Errors.All(e => e.Severity != Severity.Error);

    public virtual ValidationResult ValidationResult { get; set; }

    public virtual async Task Validate(IValidator validator)
    {
        ValidationResult validationResult;
        //validationResult = await validator.ValidateAsync(this);
        //ValidationResult = validationResult;
    }

    internal void SetValidationResult(ValidationResult validationResult)
    {
        ValidationResult = validationResult;
    }
}
