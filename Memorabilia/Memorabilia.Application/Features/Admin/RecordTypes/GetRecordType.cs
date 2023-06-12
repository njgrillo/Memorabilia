namespace Memorabilia.Application.Features.Admin.RecordTypes;

public record GetRecordType(int Id) : IQuery<Entity.RecordType>
{
    public class Handler : QueryHandler<GetRecordType, Entity.RecordType>
    {
        private readonly IDomainRepository<Entity.RecordType> _recordTypeRepository;

        public Handler(IDomainRepository<Entity.RecordType> recordTypeRepository)
        {
            _recordTypeRepository = recordTypeRepository;
        }

        protected override async Task<Entity.RecordType> Handle(GetRecordType query)
            => await _recordTypeRepository.Get(query.Id);
    }
}
