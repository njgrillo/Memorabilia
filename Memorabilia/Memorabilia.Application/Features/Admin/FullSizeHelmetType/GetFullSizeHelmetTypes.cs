using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FullSizeHelmetType
{
    public class GetFullSizeHelmetTypes
    {
        public class Handler : QueryHandler<Query, FullSizeHelmetTypesViewModel>
        {
            private readonly IFullSizeHelmetTypeRepository _fullSizeHelmetTypeRepository;

            public Handler(IFullSizeHelmetTypeRepository fullSizeHelmetTypeRepository)
            {
                _fullSizeHelmetTypeRepository = fullSizeHelmetTypeRepository;
            }

            protected override async Task<FullSizeHelmetTypesViewModel> Handle(Query query)
            {
                var fullSizeHelmetTypes = await _fullSizeHelmetTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new FullSizeHelmetTypesViewModel(fullSizeHelmetTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<FullSizeHelmetTypesViewModel>
        {
        }
    }
}
