using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyLevelType
{
    public class GetJerseyLevelType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IJerseyLevelTypeRepository _jerseyLevelTypeRepository;

            public Handler(IJerseyLevelTypeRepository jerseyLevelTypeRepository)
            {
                _jerseyLevelTypeRepository = jerseyLevelTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var jerseyLevelType = await _jerseyLevelTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(jerseyLevelType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id)
            {
            }
        }
    }
}
