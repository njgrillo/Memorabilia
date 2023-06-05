namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaItem<T, TResponse>(int MemorabiliaId) : IQuery<TResponse>
{
    public class Handler : QueryHandler<GetMemorabiliaItem<T, TResponse>, TResponse>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<TResponse> Handle(GetMemorabiliaItem<T, TResponse> request)
        {
            Entity.Memorabilia item = await _memorabiliaRepository.Get(request.MemorabiliaId);

            return (TResponse)Activator.CreateInstance(typeof(TResponse), item);
        }
    }
}
