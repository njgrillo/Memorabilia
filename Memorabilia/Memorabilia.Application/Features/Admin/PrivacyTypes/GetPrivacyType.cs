namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

public record GetPrivacyType(int Id) : IQuery<Entity.PrivacyType>
{
    public class Handler : QueryHandler<GetPrivacyType, Entity.PrivacyType>
    {
        private readonly IDomainRepository<Entity.PrivacyType> _privacyTypeRepository;

        public Handler(IDomainRepository<Entity.PrivacyType> privacyTypeRepository)
        {
            _privacyTypeRepository = privacyTypeRepository;
        }

        protected override async Task<Entity.PrivacyType> Handle(GetPrivacyType query)
            => await _privacyTypeRepository.Get(query.Id);
    }
}
