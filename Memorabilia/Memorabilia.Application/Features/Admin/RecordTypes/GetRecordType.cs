using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.RecordTypes
{
    public class GetRecordType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IRecordTypeRepository _recordTypeRepository;

            public Handler(IRecordTypeRepository recordTypeRepository)
            {
                _recordTypeRepository = recordTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _recordTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
