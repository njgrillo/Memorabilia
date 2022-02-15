using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BatType
{
    public class GetBatTypes
    {
        public class Handler : QueryHandler<Query, BatTypesViewModel>
        {
            private readonly IBatTypeRepository _batTypeRepository;

            public Handler(IBatTypeRepository batTypeRepository)
            {
                _batTypeRepository = batTypeRepository;
            }

            protected override async Task<BatTypesViewModel> Handle(Query query)
            {
                var batTypes = await _batTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new BatTypesViewModel(batTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<BatTypesViewModel> { }
    }
}
