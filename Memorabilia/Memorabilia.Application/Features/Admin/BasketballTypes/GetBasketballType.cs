namespace Memorabilia.Application.Features.Admin.BasketballTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetBasketballType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetBasketballType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.BasketballType> _basketballTypeRepository;

        public Handler(IDomainRepository<Entity.BasketballType> basketballTypeRepository)
        {
            _basketballTypeRepository = basketballTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetBasketballType query)
            => await _basketballTypeRepository.Get(query.Id);
    }
}
