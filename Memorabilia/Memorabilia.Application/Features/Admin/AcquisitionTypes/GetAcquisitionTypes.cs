namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public record GetAcquisitionTypes() : IQuery<Entity.AcquisitionType[]>
{
    public class Handler(IDomainRepository<Entity.AcquisitionType> acquisitionTypeRepository) 
        : QueryHandler<GetAcquisitionTypes, Entity.AcquisitionType[]>
    {
        protected override async Task<Entity.AcquisitionType[]> Handle(GetAcquisitionTypes query)
            => await acquisitionTypeRepository.GetAll();
    }
}
