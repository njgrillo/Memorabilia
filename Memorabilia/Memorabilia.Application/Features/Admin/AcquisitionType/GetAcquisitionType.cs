using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.AcquisitionType
{
    public class GetAcquisitionType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IAcquisitionTypeRepository _acquisitionTypeRepository;

            public Handler(IAcquisitionTypeRepository acquisitionTypeRepository)
            {
                _acquisitionTypeRepository = acquisitionTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var acquisitionType = await _acquisitionTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(acquisitionType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
