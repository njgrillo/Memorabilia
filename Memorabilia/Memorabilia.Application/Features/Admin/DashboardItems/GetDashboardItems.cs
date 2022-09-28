namespace Memorabilia.Application.Features.Admin.DashboardItems
{
    public class GetDashboardItems
    {
        public class Handler : QueryHandler<Query, DashboardItemsViewModel>
        {
            private readonly IDashboardItemRepository _dashboardItemRepository;

            public Handler(IDashboardItemRepository dashboardItemRepository)
            {
                _dashboardItemRepository = dashboardItemRepository;
            }

            protected override async Task<DashboardItemsViewModel> Handle(Query query)
            {
                return new DashboardItemsViewModel(await _dashboardItemRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<DashboardItemsViewModel>
        {
            public Query() { }
        }
    }
}
