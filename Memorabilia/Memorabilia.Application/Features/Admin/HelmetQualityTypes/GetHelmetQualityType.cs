namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

public record GetHelmetQualityType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.HelmetQualityType> helmetQualityTypeRepository) 
        : QueryHandler<GetHelmetQualityType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetHelmetQualityType query)
            => await helmetQualityTypeRepository.Get(query.Id);
    }
}
