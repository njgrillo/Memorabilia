using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.AuthenticType
{
    public class GetAuthenticTypes
    {
        public class Handler : QueryHandler<Query, AuthenticTypesViewModel>
        {
            private readonly IAuthenticTypeRepository _authenticTypeRepository;

            public Handler(IAuthenticTypeRepository authenticTypeRepository)
            {
                _authenticTypeRepository = authenticTypeRepository;
            }

            protected override async Task<AuthenticTypesViewModel> Handle(Query query)
            {
                var authenticTypes = await _authenticTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new AuthenticTypesViewModel(authenticTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<AuthenticTypesViewModel>
        {
        }
    }
}
