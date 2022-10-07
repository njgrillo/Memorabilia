using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.RecordTypes;

public class GetRecordType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<RecordType> _recordTypeRepository;

        public Handler(IDomainRepository<RecordType> recordTypeRepository)
        {
            _recordTypeRepository = recordTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _recordTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
