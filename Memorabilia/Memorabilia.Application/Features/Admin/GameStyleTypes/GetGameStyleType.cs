namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetGameStyleType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetGameStyleType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.GameStyleType> _gameStyleTypeRepository;

        public Handler(IDomainRepository<Entity.GameStyleType> gameStyleTypeRepository)
        {
            _gameStyleTypeRepository = gameStyleTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetGameStyleType query)
            => await _gameStyleTypeRepository.Get(query.Id);
    }
}
