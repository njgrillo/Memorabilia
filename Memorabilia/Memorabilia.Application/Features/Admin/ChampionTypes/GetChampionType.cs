using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ChampionTypes;

public record GetChampionType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetChampionType, DomainModel>
    {
        private readonly IDomainRepository<ChampionType> _championTypeRepository;

        public Handler(IDomainRepository<ChampionType> championTypeRepository)
        {
            _championTypeRepository = championTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetChampionType query)
        {
            return new DomainModel(await _championTypeRepository.Get(query.Id));
        }
    }
}
