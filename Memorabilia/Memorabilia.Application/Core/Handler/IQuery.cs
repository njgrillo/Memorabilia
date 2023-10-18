namespace Memorabilia.Application.Core.Handler;

public interface IQuery<out TResponse> : IRequest<TResponse> { }
