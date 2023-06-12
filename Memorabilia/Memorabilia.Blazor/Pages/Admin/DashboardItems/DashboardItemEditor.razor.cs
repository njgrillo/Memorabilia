using DashboardItemModel = Memorabilia.Application.Features.Admin.DashboardItems.DashboardItemModel;

namespace Memorabilia.Blazor.Pages.Admin.DashboardItems;

public partial class DashboardItemEditor 
    : EditItem<DashboardItemEditModel, DashboardItemModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveDashboardItem(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new DashboardItemEditModel(new DashboardItemModel(await QueryRouter.Send(new GetDashboardItem(Id))));
    }
}
