namespace Memorabilia.Application.Features.Admin.BasketballTypes;

public record GetBasketballTypes() : IQuery<Entity.BasketballType[]>
{
    public class Handler(IDomainRepository<Entity.BasketballType> basketballTypeRepository) 
        : QueryHandler<GetBasketballTypes, Entity.BasketballType[]>
    {
        protected override async Task<Entity.BasketballType[]> Handle(GetBasketballTypes query)
            => await basketballTypeRepository.GetAll();
    }
}
