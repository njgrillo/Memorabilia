namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveInscriptionType(DomainEditModel InscriptionType) : ICommand
{
    public class Handler(IDomainRepository<Entity.InscriptionType> inscriptionTypeRepository) 
        : CommandHandler<SaveInscriptionType>
    {
        protected override async Task Handle(SaveInscriptionType request)
        {
            Entity.InscriptionType inscriptionType;

            if (request.InscriptionType.IsNew)
            {
                inscriptionType = new Entity.InscriptionType(request.InscriptionType.Name, 
                                                             request.InscriptionType.Abbreviation);

                await inscriptionTypeRepository.Add(inscriptionType);

                return;
            }

            inscriptionType = await inscriptionTypeRepository.Get(request.InscriptionType.Id);

            if (request.InscriptionType.IsDeleted)
            {
                await inscriptionTypeRepository.Delete(inscriptionType);

                return;
            }

            inscriptionType.Set(request.InscriptionType.Name, 
                                request.InscriptionType.Abbreviation);

            await inscriptionTypeRepository.Update(inscriptionType);
        }
    }
}
