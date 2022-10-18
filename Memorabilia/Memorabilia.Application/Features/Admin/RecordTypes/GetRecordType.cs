using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.RecordTypes;

public record GetRecordType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetRecordType, DomainViewModel>
    {
        private readonly IDomainRepository<RecordType> _recordTypeRepository;

        public Handler(IDomainRepository<RecordType> recordTypeRepository)
        {
            _recordTypeRepository = recordTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetRecordType query)
        {
            return new DomainViewModel(await _recordTypeRepository.Get(query.Id));
        }
    }
}
