using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyStyleType
{
    public class GetJerseyStyleType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IJerseyStyleTypeRepository _jerseyStyleTypeRepository;

            public Handler(IJerseyStyleTypeRepository jerseyStyleTypeRepository)
            {
                _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var jerseyStyleType = await _jerseyStyleTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(jerseyStyleType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
