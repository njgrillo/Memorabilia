using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

public record SaveInscriptionType(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveInscriptionType>
    {
        private readonly IDomainRepository<InscriptionType> _inscriptionTypeRepository;

        public Handler(IDomainRepository<InscriptionType> inscriptionTypeRepository)
        {
            _inscriptionTypeRepository = inscriptionTypeRepository;
        }

        protected override async Task Handle(SaveInscriptionType request)
        {
            InscriptionType inscriptionType;

            if (request.ViewModel.IsNew)
            {
                inscriptionType = new InscriptionType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _inscriptionTypeRepository.Add(inscriptionType);

                return;
            }

            inscriptionType = await _inscriptionTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _inscriptionTypeRepository.Delete(inscriptionType);

                return;
            }

            inscriptionType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _inscriptionTypeRepository.Update(inscriptionType);
        }
    }
}
