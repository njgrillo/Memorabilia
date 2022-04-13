using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.RecordTypes
{
    public class GetRecordTypes
    {
        public class Handler : QueryHandler<Query, RecordTypesViewModel>
        {
            private readonly IRecordTypeRepository _recordTypeRepository;

            public Handler(IRecordTypeRepository recordTypeRepository)
            {
                _recordTypeRepository = recordTypeRepository;
            }

            protected override async Task<RecordTypesViewModel> Handle(Query query)
            {
                return new RecordTypesViewModel(await _recordTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<RecordTypesViewModel> { }
    }
}
