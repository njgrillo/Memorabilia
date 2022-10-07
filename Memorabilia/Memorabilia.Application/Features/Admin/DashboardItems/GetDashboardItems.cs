using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.DashboardItems;

public class GetDashboardItems
{
    public class Handler : QueryHandler<Query, DashboardItemsViewModel>
    {
        private readonly IDomainRepository<DashboardItem> _dashboardItemRepository;

        public Handler(IDomainRepository<DashboardItem> dashboardItemRepository)
        {
            _dashboardItemRepository = dashboardItemRepository;
        }

        protected override async Task<DashboardItemsViewModel> Handle(Query query)
        {
            return new DashboardItemsViewModel(await _dashboardItemRepository.GetAll());
        }
    }

    public class Query : IQuery<DashboardItemsViewModel>
    {
        public Query() { }
    }
}
