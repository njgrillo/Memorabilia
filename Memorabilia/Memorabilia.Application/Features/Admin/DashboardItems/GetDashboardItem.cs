using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.DashboardItems;

public record GetDashboardItem(int Id) : IQuery<DashboardItemViewModel>
{
    public class Handler : QueryHandler<GetDashboardItem, DashboardItemViewModel>
    {
        private readonly IDomainRepository<DashboardItem> _dashboardItemRepository;

        public Handler(IDomainRepository<DashboardItem> dashboardItemRepository)
        {
            _dashboardItemRepository = dashboardItemRepository;
        }

        protected override async Task<DashboardItemViewModel> Handle(GetDashboardItem query)
        {
            return new DashboardItemViewModel(await _dashboardItemRepository.Get(query.Id));
        }
    }
}
