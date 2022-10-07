using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Dashboard;

public interface IDashboardItemRule
{
    bool Applies(DashboardItem dashboardItem);

    DashboardItemViewModel Get(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems);
}
