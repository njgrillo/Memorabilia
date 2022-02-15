using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyStyleType
{
    public class GetJerseyStyleTypes
    {
        public class Handler : QueryHandler<Query, JerseyStyleTypesViewModel>
        {
            private readonly IJerseyStyleTypeRepository _jerseyStyleTypeRepository;

            public Handler(IJerseyStyleTypeRepository jerseyStyleTypeRepository)
            {
                _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
            }

            protected override async Task<JerseyStyleTypesViewModel> Handle(Query query)
            {
                var jerseyStyleTypes = await _jerseyStyleTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new JerseyStyleTypesViewModel(jerseyStyleTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<JerseyStyleTypesViewModel> { }
    }
}
