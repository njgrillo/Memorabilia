using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.HelmetQualityType
{
    public class GetHelmetQualityTypes
    {
        public class Handler : QueryHandler<Query, HelmetQualityTypesViewModel>
        {
            private readonly IHelmetQualityTypeRepository _helmetQualityTypeRepository;

            public Handler(IHelmetQualityTypeRepository helmetQualityTypeRepository)
            {
                _helmetQualityTypeRepository = helmetQualityTypeRepository;
            }

            protected override async Task<HelmetQualityTypesViewModel> Handle(Query query)
            {
                var helmetQualityTypes = await _helmetQualityTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new HelmetQualityTypesViewModel(helmetQualityTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<HelmetQualityTypesViewModel> { }
    }
}
