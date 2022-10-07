using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InscriptionTypes;

public class GetInscriptionType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<InscriptionType> _inscriptionTypeRepository;

        public Handler(IDomainRepository<InscriptionType> inscriptionTypeRepository)
        {
            _inscriptionTypeRepository = inscriptionTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _inscriptionTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
