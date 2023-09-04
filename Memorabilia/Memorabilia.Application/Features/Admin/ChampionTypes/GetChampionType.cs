namespace Memorabilia.Application.Features.Admin.ChampionTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetChampionType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetChampionType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.ChampionType> _championTypeRepository;

        public Handler(IDomainRepository<Entity.ChampionType> championTypeRepository)
        {
            _championTypeRepository = championTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetChampionType query)
            => await _championTypeRepository.Get(query.Id);
    }
}
