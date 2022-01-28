using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyNumberType
{
    public class GetJerseyNumberType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IJerseyNumberTypeRepository _jerseyNumberTypeRepository;

            public Handler(IJerseyNumberTypeRepository jerseyNumberTypeRepository)
            {
                _jerseyNumberTypeRepository = jerseyNumberTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var jerseyNumberType = await _jerseyNumberTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(jerseyNumberType);

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
