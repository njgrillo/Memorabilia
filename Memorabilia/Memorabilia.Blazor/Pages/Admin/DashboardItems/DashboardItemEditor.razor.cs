using DashboardItemModel = Memorabilia.Application.Features.Admin.DashboardItems.DashboardItemModel;

namespace Memorabilia.Blazor.Pages.Admin.DashboardItems;

public partial class DashboardItemEditor 
    : EditItem<DashboardItemEditModel, DashboardItemModel>
{   
    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await Mediator.Send(new GetDashboardItem(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveDashboardItem(EditModel));
    }
}
