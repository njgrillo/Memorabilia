namespace Memorabilia.Application.Features.Admin.PriorityTypes
{
    public class GetPriorityType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IPriorityTypeRepository _priorityTypeRepository;

            public Handler(IPriorityTypeRepository priorityTypeRepository)
            {
                _priorityTypeRepository = priorityTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _priorityTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
