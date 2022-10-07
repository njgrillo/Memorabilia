using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Dashboard;

public abstract class DashboardItemRule
{
    public abstract DashboardItem DashboardItem { get; set; }
}
