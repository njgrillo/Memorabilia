using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.AcquisitionType
{
    public class GetAcquisitionTypes
    {
        public class Handler : QueryHandler<Query, AcquisitionTypesViewModel>
        {
            private readonly IAcquisitionTypeRepository _acquisitionTypeRepository;

            public Handler(IAcquisitionTypeRepository acquisitionTypeRepository)
            {
                _acquisitionTypeRepository = acquisitionTypeRepository;
            }

            protected override async Task<AcquisitionTypesViewModel> Handle(Query query)
            {
                var acquisitionTypes = await _acquisitionTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new AcquisitionTypesViewModel(acquisitionTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<AcquisitionTypesViewModel>
        {
        }
    }
}
