namespace Memorabilia.Application.Features.Admin.BasketballTypes;

public record GetBasketballType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.BasketballType> basketballTypeRepository) 
        : QueryHandler<GetBasketballType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetBasketballType query)
            => await basketballTypeRepository.Get(query.Id);
    }
}
