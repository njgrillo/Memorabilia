namespace Memorabilia.Application.Features.Admin.BasketballTypes;

public record GetBasketballTypes() : IQuery<Entity.BasketballType[]>
{
    public class Handler : QueryHandler<GetBasketballTypes, Entity.BasketballType[]>
    {
        private readonly IDomainRepository<Entity.BasketballType> _basketballTypeRepository;

        public Handler(IDomainRepository<Entity.BasketballType> basketballTypeRepository)
        {
            _basketballTypeRepository = basketballTypeRepository;
        }

        protected override async Task<Entity.BasketballType[]> Handle(GetBasketballTypes query)
            => (await _basketballTypeRepository.GetAll()).ToArray();
    }
}
