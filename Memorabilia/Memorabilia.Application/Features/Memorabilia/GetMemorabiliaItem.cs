namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaItem(int Id) 
    : IQuery<Entity.Memorabilia>
{
    public class Handler : QueryHandler<GetMemorabiliaItem, Entity.Memorabilia>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<Entity.Memorabilia> Handle(GetMemorabiliaItem query)
            => await _memorabiliaRepository.Get(query.Id);
    }
}
