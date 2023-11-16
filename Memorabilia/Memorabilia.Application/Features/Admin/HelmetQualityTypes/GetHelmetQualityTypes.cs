namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

public record GetHelmetQualityTypes() : IQuery<Entity.HelmetQualityType[]>
{
    public class Handler(IDomainRepository<Entity.HelmetQualityType> helmetQualityTypeRepository) 
        : QueryHandler<GetHelmetQualityTypes, Entity.HelmetQualityType[]>
    {
        protected override async Task<Entity.HelmetQualityType[]> Handle(GetHelmetQualityTypes query)
            => await helmetQualityTypeRepository.GetAll();
    }
}
