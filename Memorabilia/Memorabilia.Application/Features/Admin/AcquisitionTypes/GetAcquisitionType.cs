using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.AcquisitionTypes
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
                return new DomainViewModel(await _acquisitionTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
