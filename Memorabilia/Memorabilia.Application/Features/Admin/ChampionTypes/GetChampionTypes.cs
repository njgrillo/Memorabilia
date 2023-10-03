namespace Memorabilia.Application.Features.Admin.ChampionTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetChampionTypes() : IQuery<Entity.ChampionType[]>
{
    public class Handler : QueryHandler<GetChampionTypes, Entity.ChampionType[]>
    {
        private readonly IDomainRepository<Entity.ChampionType> _championTypeRepository;

        public Handler(IDomainRepository<Entity.ChampionType> championTypeRepository)
        {
            _championTypeRepository = championTypeRepository;
        }

        protected override async Task<Entity.ChampionType[]> Handle(GetChampionTypes query)
            => await _championTypeRepository.GetAll();
    }
}
