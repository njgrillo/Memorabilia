using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FootballType
{
    public class GetFootballType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IFootballTypeRepository _footballTypeRepository;

            public Handler(IFootballTypeRepository footballTypeRepository)
            {
                _footballTypeRepository = footballTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var footballType = await _footballTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(footballType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
