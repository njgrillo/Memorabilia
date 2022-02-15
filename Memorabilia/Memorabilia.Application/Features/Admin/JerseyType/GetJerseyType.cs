using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.JerseyType
{
    public class GetJerseyType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IJerseyTypeRepository _jerseyTypeRepository;

            public Handler(IJerseyTypeRepository jerseyTypeRepository)
            {
                _jerseyTypeRepository = jerseyTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var jerseyType = await _jerseyTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(jerseyType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
