using MediatR;

namespace Demo.Framework.Handler
{
    public interface IQuery<out TResponse> : IRequest<TResponse> { }
}
