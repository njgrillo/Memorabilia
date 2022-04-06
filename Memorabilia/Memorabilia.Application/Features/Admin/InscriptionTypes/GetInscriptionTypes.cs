using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.InscriptionTypes
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
                return new InscriptionTypesViewModel(await _inscriptionTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<InscriptionTypesViewModel> { }
    }
}
