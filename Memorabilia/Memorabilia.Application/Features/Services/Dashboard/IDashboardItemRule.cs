using Memorabilia.Application.Features.User.Dashboard;
using Memorabilia.Domain.Constants;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Services.Dashboard
{
    public interface IDashboardItemRule
    {
        bool Applies(DashboardItem dashboardItem);

        DashboardItemViewModel Get(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems);
    }
}
