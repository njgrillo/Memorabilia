using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.RecordTypes;

public record GetRecordTypes() : IQuery<RecordTypesViewModel>
{
    public class Handler : QueryHandler<GetRecordTypes, RecordTypesViewModel>
    {
        private readonly IDomainRepository<RecordType> _recordTypeRepository;

        public Handler(IDomainRepository<RecordType> recordTypeRepository)
        {
            _recordTypeRepository = recordTypeRepository;
        }

        protected override async Task<RecordTypesViewModel> Handle(GetRecordTypes query)
        {
            return new RecordTypesViewModel(await _recordTypeRepository.GetAll());
        }
    }
}
