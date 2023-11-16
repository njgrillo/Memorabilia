namespace Memorabilia.Application.Features.Admin.RecordTypes;

public record GetRecordTypes() : IQuery<Entity.RecordType[]>
{
    public class Handler(IDomainRepository<Entity.RecordType> recordTypeRepository) 
        : QueryHandler<GetRecordTypes, Entity.RecordType[]>
    {
        protected override async Task<Entity.RecordType[]> Handle(GetRecordTypes query)
            => await recordTypeRepository.GetAll();
    }
}
