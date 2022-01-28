using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Sport
{
    public class GetSport
    {
        public class Handler : QueryHandler<Query, SportViewModel>
        {
            private readonly ISportRepository _sportRepository;

            public Handler(ISportRepository sportRepository)
            {
                _sportRepository = sportRepository;
            }

            protected override async Task<SportViewModel> Handle(Query query)
            {
                var sport = await _sportRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new SportViewModel(sport);

                return viewModel;
            }
        }

        public class Query : IQuery<SportViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
