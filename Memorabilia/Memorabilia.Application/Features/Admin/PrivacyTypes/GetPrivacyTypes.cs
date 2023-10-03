namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetPrivacyTypes() : IQuery<Entity.PrivacyType[]>
{
    public class Handler : QueryHandler<GetPrivacyTypes, Entity.PrivacyType[]>
    {
        private readonly IDomainRepository<Entity.PrivacyType> _privacyTypeRepository;

        public Handler(IDomainRepository<Entity.PrivacyType> privacyTypeRepository)
        {
            _privacyTypeRepository = privacyTypeRepository;
        }

        protected override async Task<Entity.PrivacyType[]> Handle(GetPrivacyTypes query)
            => await _privacyTypeRepository.GetAll();
    }
}
