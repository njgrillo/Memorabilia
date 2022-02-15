using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.InscriptionType
{
    public class GetInscriptionType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IInscriptionTypeRepository _inscriptionTypeRepository;

            public Handler(IInscriptionTypeRepository inscriptionTypeRepository)
            {
                _inscriptionTypeRepository = inscriptionTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var inscriptionType = await _inscriptionTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(inscriptionType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
