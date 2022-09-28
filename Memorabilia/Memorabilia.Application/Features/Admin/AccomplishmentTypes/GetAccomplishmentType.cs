namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes
{
    public class GetAccomplishmentType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IAccomplishmentTypeRepository _accomplishmentTypeRepository;

            public Handler(IAccomplishmentTypeRepository accomplishmentTypeRepository)
            {
                _accomplishmentTypeRepository = accomplishmentTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _accomplishmentTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
