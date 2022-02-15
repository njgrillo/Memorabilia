using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.HelmetQualityType
{
    public class GetHelmetQualityType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IHelmetQualityTypeRepository _helmetQualityTypeRepository;

            public Handler(IHelmetQualityTypeRepository helmetQualityTypeRepository)
            {
                _helmetQualityTypeRepository = helmetQualityTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var helmetQualityType = await _helmetQualityTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(helmetQualityType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
