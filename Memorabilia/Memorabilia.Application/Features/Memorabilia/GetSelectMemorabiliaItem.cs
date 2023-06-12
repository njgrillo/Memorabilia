namespace Memorabilia.Application.Features.Memorabilia;

public record GetSelectMemorabiliaItem(int Id) 
    : IQuery<Entity.Memorabilia>
{
    public class Handler : QueryHandler<GetSelectMemorabiliaItem, Entity.Memorabilia>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<Entity.Memorabilia> Handle(GetSelectMemorabiliaItem query)
            => await _memorabiliaRepository.Get(query.Id);
    }
}
