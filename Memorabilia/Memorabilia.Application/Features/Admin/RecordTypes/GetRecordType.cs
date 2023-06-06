using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.RecordTypes;

public record GetRecordType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetRecordType, DomainModel>
    {
        private readonly IDomainRepository<RecordType> _recordTypeRepository;

        public Handler(IDomainRepository<RecordType> recordTypeRepository)
        {
            _recordTypeRepository = recordTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetRecordType query)
        {
            return new DomainModel(await _recordTypeRepository.Get(query.Id));
        }
    }
}
