namespace Memorabilia.Domain.Command;

public interface IDomainCommand
{
    bool IsValid { get; }

    ValidationResult ValidationResult { get; }

    Task Validate([NotNull] IValidator validator);
}
