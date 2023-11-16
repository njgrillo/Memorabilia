namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

public record GetPrivacyType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.PrivacyType> privacyTypeRepository) 
        : QueryHandler<GetPrivacyType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetPrivacyType query)
            => await privacyTypeRepository.Get(query.Id);
    }
}
