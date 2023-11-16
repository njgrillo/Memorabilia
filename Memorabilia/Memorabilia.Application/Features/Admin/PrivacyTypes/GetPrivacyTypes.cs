namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

public record GetPrivacyTypes() : IQuery<Entity.PrivacyType[]>
{
    public class Handler(IDomainRepository<Entity.PrivacyType> privacyTypeRepository) 
        : QueryHandler<GetPrivacyTypes, Entity.PrivacyType[]>
    {
        protected override async Task<Entity.PrivacyType[]> Handle(GetPrivacyTypes query)
            => await privacyTypeRepository.GetAll();
    }
}
