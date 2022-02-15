using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyType
{
    public class GetJerseyTypes
    {
        public class Handler : QueryHandler<Query, JerseyTypesViewModel>
        {
            private readonly IJerseyTypeRepository _jerseyTypeRepository;

            public Handler(IJerseyTypeRepository jerseyTypeRepository)
            {
                _jerseyTypeRepository = jerseyTypeRepository;
            }

            protected override async Task<JerseyTypesViewModel> Handle(Query query)
            {
                var jerseyTypes = await _jerseyTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new JerseyTypesViewModel(jerseyTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<JerseyTypesViewModel> { }
    }
}
