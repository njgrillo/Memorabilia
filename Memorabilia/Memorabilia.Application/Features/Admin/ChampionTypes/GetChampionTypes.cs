using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ChampionTypes;

public class GetChampionTypes
{
    public class Handler : QueryHandler<Query, ChampionTypesViewModel>
    {
        private readonly IDomainRepository<ChampionType> _championTypeRepository;

        public Handler(IDomainRepository<ChampionType> championTypeRepository)
        {
            _championTypeRepository = championTypeRepository;
        }

        protected override async Task<ChampionTypesViewModel> Handle(Query query)
        {
            return new ChampionTypesViewModel(await _championTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<ChampionTypesViewModel> { }
}
