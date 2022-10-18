using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

public record GetInscriptionTypes() : IQuery<InscriptionTypesViewModel>
{
    public class Handler : QueryHandler<GetInscriptionTypes, InscriptionTypesViewModel>
    {
        private readonly IDomainRepository<InscriptionType> _inscriptionTypeRepository;

        public Handler(IDomainRepository<InscriptionType> inscriptionTypeRepository)
        {
            _inscriptionTypeRepository = inscriptionTypeRepository;
        }

        protected override async Task<InscriptionTypesViewModel> Handle(GetInscriptionTypes query)
        {
            return new InscriptionTypesViewModel(await _inscriptionTypeRepository.GetAll());
        }
    }
}
