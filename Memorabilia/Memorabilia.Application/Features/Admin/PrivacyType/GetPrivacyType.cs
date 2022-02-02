using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.PrivacyType
{
    public class GetPrivacyType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IPrivacyTypeRepository _privacyTypeRepository;

            public Handler(IPrivacyTypeRepository privacyTypeRepository)
            {
                _privacyTypeRepository = privacyTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var privacyType = await _privacyTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(privacyType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id)
            {
            }
        }
    }
}
