using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ChampionTypes;

public record GetChampionTypes() : IQuery<ChampionTypesViewModel>
{
    public class Handler : QueryHandler<GetChampionTypes, ChampionTypesViewModel>
    {
        private readonly IDomainRepository<ChampionType> _championTypeRepository;

        public Handler(IDomainRepository<ChampionType> championTypeRepository)
        {
            _championTypeRepository = championTypeRepository;
        }

        protected override async Task<ChampionTypesViewModel> Handle(GetChampionTypes query)
        {
            return new ChampionTypesViewModel(await _championTypeRepository.GetAll());
        }
    }
}
