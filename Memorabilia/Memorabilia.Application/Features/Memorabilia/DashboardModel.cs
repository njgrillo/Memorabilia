using DashboardItemModel = Memorabilia.Application.Features.Dashboard.DashboardItemModel;

namespace Memorabilia.Application.Features.Memorabilia;

public class DashboardModel : Model
{
    public DashboardModel() { }

    public DashboardModel(IEnumerable<DashboardItemModel> items)
    {
        UserDashboardItems = items;
    }        

    public override string PageTitle 
        => "Dashboard";

    public IEnumerable<DashboardItemModel> UserDashboardItems { get; set; }
        = Enumerable.Empty<DashboardItemModel>();
}
