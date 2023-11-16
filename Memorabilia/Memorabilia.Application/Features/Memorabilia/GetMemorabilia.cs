namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabilia<T>(int MemorabiliaId) 
    : IQuery<T> where T : new()
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : QueryHandler<GetMemorabilia<T>, T>
    {
        protected override async Task<T> Handle(GetMemorabilia<T> request)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(request.MemorabiliaId);

            return (T)Activator.CreateInstance(typeof(T), memorabilia);
        }
    }
}
