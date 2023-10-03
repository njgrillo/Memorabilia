namespace Memorabilia.Application.Features.Admin.RecordTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetRecordType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetRecordType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.RecordType> _recordTypeRepository;

        public Handler(IDomainRepository<Entity.RecordType> recordTypeRepository)
        {
            _recordTypeRepository = recordTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetRecordType query)
            => await _recordTypeRepository.Get(query.Id);
    }
}
