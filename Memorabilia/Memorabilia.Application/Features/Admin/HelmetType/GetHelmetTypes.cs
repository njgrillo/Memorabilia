using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.HelmetType
{
    public class GetHelmetTypes
    {
        public class Handler : QueryHandler<Query, HelmetTypesViewModel>
        {
            private readonly IHelmetTypeRepository _helmetTypeRepository;

            public Handler(IHelmetTypeRepository helmetTypeRepository)
            {
                _helmetTypeRepository = helmetTypeRepository;
            }

            protected override async Task<HelmetTypesViewModel> Handle(Query query)
            {
                var helmetTypes = await _helmetTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new HelmetTypesViewModel(helmetTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<HelmetTypesViewModel> { }
    }
}
