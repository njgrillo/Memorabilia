namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public record GetItemTypeSports(int? ItemTypeId = null) : IQuery<Entity.ItemTypeSport[]>
{
    public class Handler : QueryHandler<GetItemTypeSports, Entity.ItemTypeSport[]>
    {
        private readonly IItemTypeSportRepository _itemTypeSportRepository;

        public Handler(IItemTypeSportRepository itemTypeSportRepository)
        {
            _itemTypeSportRepository = itemTypeSportRepository;
        }

        protected override async Task<Entity.ItemTypeSport[]> Handle(GetItemTypeSports query)
            => await _itemTypeSportRepository.GetAll(query.ItemTypeId);
    }
}
