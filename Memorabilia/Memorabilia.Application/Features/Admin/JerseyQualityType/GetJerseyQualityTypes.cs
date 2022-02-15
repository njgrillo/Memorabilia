using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyQualityType
{
    public class GetJerseyQualityTypes
    {
        public class Handler : QueryHandler<Query, JerseyQualityTypesViewModel>
        {
            private readonly IJerseyQualityTypeRepository _jerseyQualityTypeRepository;

            public Handler(IJerseyQualityTypeRepository jerseyQualityTypeRepository)
            {
                _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
            }

            protected override async Task<JerseyQualityTypesViewModel> Handle(Query query)
            {
                var jerseyQualityTypes = await _jerseyQualityTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new JerseyQualityTypesViewModel(jerseyQualityTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<JerseyQualityTypesViewModel> { }
    }
}
