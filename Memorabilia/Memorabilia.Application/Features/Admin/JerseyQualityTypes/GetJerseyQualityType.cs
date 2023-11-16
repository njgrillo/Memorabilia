namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

public record GetJerseyQualityType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.JerseyQualityType> jerseyQualityTypeRepository) 
        : QueryHandler<GetJerseyQualityType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetJerseyQualityType query)
            => await jerseyQualityTypeRepository.Get(query.Id);
    }
}
