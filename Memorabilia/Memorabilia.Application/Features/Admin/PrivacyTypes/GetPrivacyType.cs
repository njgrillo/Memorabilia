namespace Memorabilia.Application.Features.Admin.PrivacyTypes
{
    public class GetPrivacyType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IPrivacyTypeRepository _privacyTypeRepository;

            public Handler(IPrivacyTypeRepository privacyTypeRepository)
            {
                _privacyTypeRepository = privacyTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _privacyTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
