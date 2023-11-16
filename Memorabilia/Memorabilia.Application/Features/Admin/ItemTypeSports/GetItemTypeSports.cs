namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public record GetItemTypeSports(int? ItemTypeId = null) : IQuery<Entity.ItemTypeSport[]>
{
    public class Handler(IItemTypeSportRepository itemTypeSportRepository) 
        : QueryHandler<GetItemTypeSports, Entity.ItemTypeSport[]>
    {
        protected override async Task<Entity.ItemTypeSport[]> Handle(GetItemTypeSports query)
            => await itemTypeSportRepository.GetAll(query.ItemTypeId);
    }
}
