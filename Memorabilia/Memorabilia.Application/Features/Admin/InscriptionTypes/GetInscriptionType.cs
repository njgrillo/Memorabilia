using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

public record GetInscriptionType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetInscriptionType, DomainViewModel>
    {
        private readonly IDomainRepository<InscriptionType> _inscriptionTypeRepository;

        public Handler(IDomainRepository<InscriptionType> inscriptionTypeRepository)
        {
            _inscriptionTypeRepository = inscriptionTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetInscriptionType query)
        {
            return new DomainViewModel(await _inscriptionTypeRepository.Get(query.Id));
        }
    }
}
