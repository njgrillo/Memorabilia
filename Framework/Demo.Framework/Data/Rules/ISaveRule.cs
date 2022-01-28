using FluentValidation.Results;
using Framework.Domain.Command;
using Framework.Domain.Entity;
using Framework.Handler;

namespace Demo.Framework.Data.Rules
{
    public interface ISaveRule<T> where T : DomainEntity
    {
        bool Applies(T entity);

        ValidationResult Execute();
    }
}
