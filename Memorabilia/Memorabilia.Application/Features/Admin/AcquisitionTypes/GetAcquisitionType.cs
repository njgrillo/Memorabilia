namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public record GetAcquisitionType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.AcquisitionType> acquisitionTypeRepository) 
        : QueryHandler<GetAcquisitionType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetAcquisitionType query)
            => await acquisitionTypeRepository.Get(query.Id);
    }
}
