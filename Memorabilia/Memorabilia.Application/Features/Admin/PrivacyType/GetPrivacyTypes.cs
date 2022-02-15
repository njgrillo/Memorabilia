using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.PrivacyType
{
    public class GetPrivacyTypes
    {
        public class Handler : QueryHandler<Query, PrivacyTypesViewModel>
        {
            private readonly IPrivacyTypeRepository _privacyTypeRepository;

            public Handler(IPrivacyTypeRepository privacyTypeRepository)
            {
                _privacyTypeRepository = privacyTypeRepository;
            }

            protected override async Task<PrivacyTypesViewModel> Handle(Query query)
            {
                var privacyTypes = await _privacyTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new PrivacyTypesViewModel(privacyTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<PrivacyTypesViewModel> { }
    }
}
