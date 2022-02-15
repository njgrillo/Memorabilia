using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.InscriptionType
{
    public class GetInscriptionTypes
    {
        public class Handler : QueryHandler<Query, InscriptionTypesViewModel>
        {
            private readonly IInscriptionTypeRepository _inscriptionTypeRepository;

            public Handler(IInscriptionTypeRepository inscriptionTypeRepository)
            {
                _inscriptionTypeRepository = inscriptionTypeRepository;
            }

            protected override async Task<InscriptionTypesViewModel> Handle(Query query)
            {
                var inscriptionTypes = await _inscriptionTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new InscriptionTypesViewModel(inscriptionTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<InscriptionTypesViewModel> { }
    }
}
