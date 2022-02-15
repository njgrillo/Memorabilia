using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyQualityType
{
    public class GetJerseyQualityType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IJerseyQualityTypeRepository _jerseyQualityTypeRepository;

            public Handler(IJerseyQualityTypeRepository jerseyQualityTypeRepository)
            {
                _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var jerseyQualityType = await _jerseyQualityTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(jerseyQualityType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
