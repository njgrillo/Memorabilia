namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SavePrivacyType(DomainEditModel PrivacyType) : ICommand
{
    public class Handler : CommandHandler<SavePrivacyType>
    {
        private readonly IDomainRepository<Entity.PrivacyType> _privacyTypeRepository;

        public Handler(IDomainRepository<Entity.PrivacyType> privacyTypeRepository)
        {
            _privacyTypeRepository = privacyTypeRepository;
        }

        protected override async Task Handle(SavePrivacyType request)
        {
            Entity.PrivacyType privacyType;

            if (request.PrivacyType.IsNew)
            {
                privacyType = new Entity.PrivacyType(request.PrivacyType.Name, 
                                                     request.PrivacyType.Abbreviation);

                await _privacyTypeRepository.Add(privacyType);

                return;
            }

            privacyType = await _privacyTypeRepository.Get(request.PrivacyType.Id);

            if (request.PrivacyType.IsDeleted)
            {
                await _privacyTypeRepository.Delete(privacyType);

                return;
            }

            privacyType.Set(request.PrivacyType.Name, 
                            request.PrivacyType.Abbreviation);

            await _privacyTypeRepository.Update(privacyType);
        }
    }
}
