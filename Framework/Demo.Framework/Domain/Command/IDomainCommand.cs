using FluentValidation;
using FluentValidation.Results;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace Framework.Domain.Command
{
    public interface IDomainCommand
    {
        bool HasInfo { get; }

        bool HasWarnings { get; }

        bool IsValid { get; }

        ValidationResult ValidationResult { get; }

        Task Validate([NotNull] IValidator validator);
    }
}
