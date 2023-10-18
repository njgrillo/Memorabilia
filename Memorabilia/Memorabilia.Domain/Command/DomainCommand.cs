namespace Memorabilia.Domain.Command;

public abstract class DomainCommand : IDomainCommand
{
    public bool IsValid 
        => ValidationResult != null && 
           ValidationResult.Errors.All(e => e.Severity != Severity.Error);

    public virtual ValidationResult ValidationResult { get; set; }
}
