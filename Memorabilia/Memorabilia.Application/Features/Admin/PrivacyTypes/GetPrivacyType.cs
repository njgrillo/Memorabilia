namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetPrivacyType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetPrivacyType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.PrivacyType> _privacyTypeRepository;

        public Handler(IDomainRepository<Entity.PrivacyType> privacyTypeRepository)
        {
            _privacyTypeRepository = privacyTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetPrivacyType query)
            => await _privacyTypeRepository.Get(query.Id);
    }
}
