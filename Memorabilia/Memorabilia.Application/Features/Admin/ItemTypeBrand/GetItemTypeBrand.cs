namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public record GetItemTypeBrand(int Id) : IQuery<Entity.ItemTypeBrand>
{
    public class Handler(IItemTypeBrandRepository itemTypeBrandRepository) 
        : QueryHandler<GetItemTypeBrand, Entity.ItemTypeBrand>
    {
        protected override async Task<Entity.ItemTypeBrand> Handle(GetItemTypeBrand query)
            => await itemTypeBrandRepository.Get(query.Id);
    }
}
