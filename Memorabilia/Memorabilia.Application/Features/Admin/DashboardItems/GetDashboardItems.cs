using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.DashboardItems;

public record GetDashboardItems() : IQuery<DashboardItemsViewModel>
{
    public class Handler : QueryHandler<GetDashboardItems, DashboardItemsViewModel>
    {
        private readonly IDomainRepository<DashboardItem> _dashboardItemRepository;

        public Handler(IDomainRepository<DashboardItem> dashboardItemRepository)
        {
            _dashboardItemRepository = dashboardItemRepository;
        }

        protected override async Task<DashboardItemsViewModel> Handle(GetDashboardItems query)
        {
            return new DashboardItemsViewModel(await _dashboardItemRepository.GetAll());
        }
    }
}
