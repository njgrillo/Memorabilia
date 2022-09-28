namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes
{
    public class GetFranchiseHallOfFameType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IFranchiseHallOfFameTypeRepository _franchiseHallOfFameTypeRepository;

            public Handler(IFranchiseHallOfFameTypeRepository franchiseHallOfFameTypeRepository)
            {
                _franchiseHallOfFameTypeRepository = franchiseHallOfFameTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _franchiseHallOfFameTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
