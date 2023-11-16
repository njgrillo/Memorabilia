namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaItem<T, TResponse>(int MemorabiliaId) : IQuery<TResponse>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : QueryHandler<GetMemorabiliaItem<T, TResponse>, TResponse>
    {
        protected override async Task<TResponse> Handle(GetMemorabiliaItem<T, TResponse> request)
        {
            Entity.Memorabilia item = await memorabiliaRepository.Get(request.MemorabiliaId);

            return (TResponse)Activator.CreateInstance(typeof(TResponse), item);
        }
    }
}
