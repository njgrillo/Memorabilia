namespace Memorabilia.Application.Features.Admin.BammerTypes
{
    public class GetBammerType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IBammerTypeRepository _bammerTypeRepository;

            public Handler(IBammerTypeRepository bammerTypeRepository)
            {
                _bammerTypeRepository = bammerTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _bammerTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
