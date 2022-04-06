using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.DashboardItems
{
    public class DashboardItemsViewModel : ViewModel
    {
        public DashboardItemsViewModel() { }

        public DashboardItemsViewModel(IEnumerable<DashboardItem> dashboardItems)
        {
            DashboardItems = dashboardItems.Select(dashboardItem => new DashboardItemViewModel(dashboardItem))
                                           .OrderBy(dashboardItem => dashboardItem.Name)
                                           .ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public List<DashboardItemViewModel> DashboardItems { get; set; } = new();

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public override string ItemTitle => "Dashboard Item";

        public override string PageTitle => "Dashboard Items";

        public override string RoutePrefix => "DashboardItems";
    }
}
