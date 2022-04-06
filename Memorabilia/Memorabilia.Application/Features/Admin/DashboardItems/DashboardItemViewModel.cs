using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.DashboardItems
{
    public class DashboardItemViewModel
    {
        private readonly DashboardItem _dashboardItem;

        public DashboardItemViewModel() { }

        public DashboardItemViewModel(DashboardItem dashboardItem)
        {
            _dashboardItem = dashboardItem;
        }

        public string Description => _dashboardItem.Description;

        public int Id => _dashboardItem.Id;

        public string Name => _dashboardItem.Name;
    }
}
