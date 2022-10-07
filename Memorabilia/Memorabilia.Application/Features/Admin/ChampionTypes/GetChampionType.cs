using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ChampionTypes;

public class GetChampionType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<ChampionType> _championTypeRepository;

        public Handler(IDomainRepository<ChampionType> championTypeRepository)
        {
            _championTypeRepository = championTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _championTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
