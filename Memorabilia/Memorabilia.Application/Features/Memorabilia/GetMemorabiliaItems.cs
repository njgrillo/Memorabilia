namespace Memorabilia.Application.Features.Memorabilia;

public record GetMemorabiliaItems(int UserId) 
    : IQuery<Entity.Memorabilia[]>
{
    public class Handler : QueryHandler<GetMemorabiliaItems, Entity.Memorabilia[]>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<Entity.Memorabilia[]> Handle(GetMemorabiliaItems query)
            => await _memorabiliaRepository.GetAll(query.UserId);
    }
}
