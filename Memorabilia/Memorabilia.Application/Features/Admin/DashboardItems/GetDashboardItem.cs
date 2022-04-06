using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.DashboardItems
{
    public class GetDashboardItem
    {
        public class Handler : QueryHandler<Query, DashboardItemViewModel>
        {
            private readonly IDashboardItemRepository _dashboardItemRepository;

            public Handler(IDashboardItemRepository dashboardItemRepository)
            {
                _dashboardItemRepository = dashboardItemRepository;
            }

            protected override async Task<DashboardItemViewModel> Handle(Query query)
            {
                return new DashboardItemViewModel(await _dashboardItemRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<DashboardItemViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
