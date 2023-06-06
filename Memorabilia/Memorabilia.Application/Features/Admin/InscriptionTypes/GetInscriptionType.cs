using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

public record GetInscriptionType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetInscriptionType, DomainModel>
    {
        private readonly IDomainRepository<InscriptionType> _inscriptionTypeRepository;

        public Handler(IDomainRepository<InscriptionType> inscriptionTypeRepository)
        {
            _inscriptionTypeRepository = inscriptionTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetInscriptionType query)
        {
            return new DomainModel(await _inscriptionTypeRepository.Get(query.Id));
        }
    }
}
