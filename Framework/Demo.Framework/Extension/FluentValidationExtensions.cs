using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Framework.Extension
{
    public static class FluentValidationExtensions
    {
        //public static IRuleBuilderOptions<T, TProperty> ValidateChildCommand<T, TProperty>([NotNull] this IRuleBuilder<T, TProperty> ruleBuilder, IValidator<TProperty> validator)
        //    where TProperty : DomainCommand
        //{
        //    return ruleBuilder.SetValidator(new ChildCommandValditorAdapter<TProperty>(validator));
        //}

        public static IEnumerable<ValidationFailure> Warnings(this ValidationResult validationResult)
        {
            return validationResult.Errors.Where(e => e.Severity == Severity.Warning);
        }

        public static IEnumerable<ValidationFailure> Info(this ValidationResult validationResult)
        {
            return validationResult.Errors.Where(e => e.Severity == Severity.Info);
        }
    }
}
