using DashboardItemViewModel = Memorabilia.Application.Features.Admin.DashboardItems.DashboardItemViewModel;

namespace Memorabilia.Blazor.Pages.Admin.DashboardItems;

public partial class DashboardItemEditor : EditItem<SaveDashboardItemViewModel, DashboardItemViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveDashboardItem(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SaveDashboardItemViewModel(await Get(new GetDashboardItem(Id)));
    }
}
