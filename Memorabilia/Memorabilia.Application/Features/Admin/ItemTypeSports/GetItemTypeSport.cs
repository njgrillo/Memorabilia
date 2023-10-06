namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public record GetItemTypeSport(int Id) : IQuery<Entity.ItemTypeSport>
{
    public class Handler : QueryHandler<GetItemTypeSport, Entity.ItemTypeSport>
    {
        private readonly IItemTypeSportRepository _itemTypeSportRepository;

        public Handler(IItemTypeSportRepository itemTypeSportRepository)
        {
            _itemTypeSportRepository = itemTypeSportRepository;
        }

        protected override async Task<Entity.ItemTypeSport> Handle(GetItemTypeSport query)
            => await _itemTypeSportRepository.Get(query.Id);
    }
}
