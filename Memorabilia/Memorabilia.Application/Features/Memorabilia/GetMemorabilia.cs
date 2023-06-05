namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabilia<T>(int MemorabiliaId) 
    : IQuery<T> where T : new()
{
    public class Handler : QueryHandler<GetMemorabilia<T>, T>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<T> Handle(GetMemorabilia<T> request)
        {
            Entity.Memorabilia memorabilia = await _memorabiliaRepository.Get(request.MemorabiliaId);

            return (T)Activator.CreateInstance(typeof(T), memorabilia);
        }
    }
}
