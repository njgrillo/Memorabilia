using DashboardItemModel = Memorabilia.Application.Features.Admin.DashboardItems.DashboardItemModel;

namespace Memorabilia.Blazor.Pages.Admin.DashboardItems;

public partial class ViewDashboardItems 
    : ViewItem<DashboardItemsModel, DashboardItemModel>
{
    protected async Task OnLoad()
    {
        Model = new DashboardItemsModel(await QueryRouter.Send(new GetDashboardItems()));
    }

    protected override async Task Delete(int id)
    {
        DashboardItemModel deletedItem 
            = Model.DashboardItems.Single(dashboardItem => dashboardItem.Id == id);

        var editModel = new DashboardItemEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveDashboardItem(editModel));

        Model.DashboardItems.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(DashboardItemModel model, string search)
        => search.IsNullOrEmpty() ||
           model.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.Description.Contains(search, StringComparison.OrdinalIgnoreCase);
}
