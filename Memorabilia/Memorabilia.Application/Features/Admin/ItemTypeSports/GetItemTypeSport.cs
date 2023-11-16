namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public record GetItemTypeSport(int Id) : IQuery<Entity.ItemTypeSport>
{
    public class Handler(IItemTypeSportRepository itemTypeSportRepository) 
        : QueryHandler<GetItemTypeSport, Entity.ItemTypeSport>
    {
        protected override async Task<Entity.ItemTypeSport> Handle(GetItemTypeSport query)
            => await itemTypeSportRepository.Get(query.Id);
    }
}
