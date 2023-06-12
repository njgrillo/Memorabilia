namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

public record SaveInscriptionType(DomainEditModel InscriptionType) : ICommand
{
    public class Handler : CommandHandler<SaveInscriptionType>
    {
        private readonly IDomainRepository<Entity.InscriptionType> _inscriptionTypeRepository;

        public Handler(IDomainRepository<Entity.InscriptionType> inscriptionTypeRepository)
        {
            _inscriptionTypeRepository = inscriptionTypeRepository;
        }

        protected override async Task Handle(SaveInscriptionType request)
        {
            Entity.InscriptionType inscriptionType;

            if (request.InscriptionType.IsNew)
            {
                inscriptionType = new Entity.InscriptionType(request.InscriptionType.Name, 
                                                             request.InscriptionType.Abbreviation);

                await _inscriptionTypeRepository.Add(inscriptionType);

                return;
            }

            inscriptionType = await _inscriptionTypeRepository.Get(request.InscriptionType.Id);

            if (request.InscriptionType.IsDeleted)
            {
                await _inscriptionTypeRepository.Delete(inscriptionType);

                return;
            }

            inscriptionType.Set(request.InscriptionType.Name, 
                                request.InscriptionType.Abbreviation);

            await _inscriptionTypeRepository.Update(inscriptionType);
        }
    }
}
