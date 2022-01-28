using FluentValidation.Results;
using MediatR;

namespace Framework.Handler
{
    public interface ICommand : IRequest //, IRequest<Unit>, IBaseRequest
    {
        bool IsValid { get; }

        ValidationResult ValidationResult { get; }
    }
}
