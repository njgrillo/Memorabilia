namespace Memorabilia.Application.Features.Admin.BaseballTypes;

public record GetBaseballType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetBaseballType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.BaseballType> _baseballTypeRepository;

        public Handler(IDomainRepository<Entity.BaseballType> baseballTypeRepository)
        {
            _baseballTypeRepository = baseballTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetBaseballType query)
            => await _baseballTypeRepository.Get(query.Id);
    }
}
