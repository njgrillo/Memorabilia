namespace Memorabilia.Application.Features.Admin.BasketballTypes;

public record GetBasketballType(int Id) : IQuery<Entity.BasketballType>
{
    public class Handler : QueryHandler<GetBasketballType, Entity.BasketballType>
    {
        private readonly IDomainRepository<Entity.BasketballType> _basketballTypeRepository;

        public Handler(IDomainRepository<Entity.BasketballType> basketballTypeRepository)
        {
            _basketballTypeRepository = basketballTypeRepository;
        }

        protected override async Task<Entity.BasketballType> Handle(GetBasketballType query)
            => await _basketballTypeRepository.Get(query.Id);
    }
}
