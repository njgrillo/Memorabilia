using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ChampionTypes;

public record GetChampionType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetChampionType, DomainViewModel>
    {
        private readonly IDomainRepository<ChampionType> _championTypeRepository;

        public Handler(IDomainRepository<ChampionType> championTypeRepository)
        {
            _championTypeRepository = championTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetChampionType query)
        {
            return new DomainViewModel(await _championTypeRepository.Get(query.Id));
        }
    }
}
