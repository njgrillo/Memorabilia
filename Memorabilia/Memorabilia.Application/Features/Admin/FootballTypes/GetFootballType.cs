namespace Memorabilia.Application.Features.Admin.FootballTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetFootballType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetFootballType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.FootballType> _footballTypeRepository;

        public Handler(IDomainRepository<Entity.FootballType> footballTypeRepository)
        {
            _footballTypeRepository = footballTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetFootballType query)
            => await _footballTypeRepository.Get(query.Id);
    }
}
