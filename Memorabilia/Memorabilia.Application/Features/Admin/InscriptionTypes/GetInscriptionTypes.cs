using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

public class GetInscriptionTypes
{
    public class Handler : QueryHandler<Query, InscriptionTypesViewModel>
    {
        private readonly IDomainRepository<InscriptionType> _inscriptionTypeRepository;

        public Handler(IDomainRepository<InscriptionType> inscriptionTypeRepository)
        {
            _inscriptionTypeRepository = inscriptionTypeRepository;
        }

        protected override async Task<InscriptionTypesViewModel> Handle(Query query)
        {
            return new InscriptionTypesViewModel(await _inscriptionTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<InscriptionTypesViewModel> { }
}
