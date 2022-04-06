using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.PrivacyTypes
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
                return new PrivacyTypesViewModel(await _privacyTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<PrivacyTypesViewModel> { }
    }
}
