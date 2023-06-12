namespace Memorabilia.Application.Features.Admin.ChampionTypes;

public record GetChampionType(int Id) : IQuery<Entity.ChampionType>
{
    public class Handler : QueryHandler<GetChampionType, Entity.ChampionType>
    {
        private readonly IDomainRepository<Entity.ChampionType> _championTypeRepository;

        public Handler(IDomainRepository<Entity.ChampionType> championTypeRepository)
        {
            _championTypeRepository = championTypeRepository;
        }

        protected override async Task<Entity.ChampionType> Handle(GetChampionType query)
            => await _championTypeRepository.Get(query.Id);
    }
}
