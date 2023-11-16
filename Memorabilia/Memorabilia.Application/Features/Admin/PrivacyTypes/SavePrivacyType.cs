namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SavePrivacyType(DomainEditModel PrivacyType) : ICommand
{
    public class Handler(IDomainRepository<Entity.PrivacyType> privacyTypeRepository) 
        : CommandHandler<SavePrivacyType>
    {
        protected override async Task Handle(SavePrivacyType request)
        {
            Entity.PrivacyType privacyType;

            if (request.PrivacyType.IsNew)
            {
                privacyType = new Entity.PrivacyType(request.PrivacyType.Name, 
                                                     request.PrivacyType.Abbreviation);

                await privacyTypeRepository.Add(privacyType);

                return;
            }

            privacyType = await privacyTypeRepository.Get(request.PrivacyType.Id);

            if (request.PrivacyType.IsDeleted)
            {
                await privacyTypeRepository.Delete(privacyType);

                return;
            }

            privacyType.Set(request.PrivacyType.Name, 
                            request.PrivacyType.Abbreviation);

            await privacyTypeRepository.Update(privacyType);
        }
    }
}
