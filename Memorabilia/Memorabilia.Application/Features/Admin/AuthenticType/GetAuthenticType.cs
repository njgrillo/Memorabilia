using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.AuthenticType
{
    public class GetAuthenticType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IAuthenticTypeRepository _authenticTypeRepository;

            public Handler(IAuthenticTypeRepository authenticTypeRepository)
            {
                _authenticTypeRepository = authenticTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var authenticType = await _authenticTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(authenticType);

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
