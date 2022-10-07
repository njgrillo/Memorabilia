using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.RecordTypes;

public class GetRecordTypes
{
    public class Handler : QueryHandler<Query, RecordTypesViewModel>
    {
        private readonly IDomainRepository<RecordType> _recordTypeRepository;

        public Handler(IDomainRepository<RecordType> recordTypeRepository)
        {
            _recordTypeRepository = recordTypeRepository;
        }

        protected override async Task<RecordTypesViewModel> Handle(Query query)
        {
            return new RecordTypesViewModel(await _recordTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<RecordTypesViewModel> { }
}
