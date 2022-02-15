using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Sport
{
    public class GetSports
    {
        public class Handler : QueryHandler<Query, SportsViewModel>
        {
            private readonly ISportRepository _sportRepository;

            public Handler(ISportRepository sportRepository)
            {
                _sportRepository = sportRepository;
            }

            protected override async Task<SportsViewModel> Handle(Query query)
            {
                var sports = await _sportRepository.GetAll().ConfigureAwait(false);

                var viewModel = new SportsViewModel(sports);

                return viewModel;
            }
        }

        public class Query : IQuery<SportsViewModel> { }
    }
}
