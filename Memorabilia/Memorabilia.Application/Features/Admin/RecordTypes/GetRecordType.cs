namespace Memorabilia.Application.Features.Admin.RecordTypes;

public record GetRecordType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.RecordType> recordTypeRepository) 
        : QueryHandler<GetRecordType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetRecordType query)
            => await recordTypeRepository.Get(query.Id);
    }
}
