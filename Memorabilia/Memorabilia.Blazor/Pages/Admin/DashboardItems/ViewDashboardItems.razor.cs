using DashboardItemModel = Memorabilia.Application.Features.Admin.DashboardItems.DashboardItemModel;

namespace Memorabilia.Blazor.Pages.Admin.DashboardItems;

public partial class ViewDashboardItems 
    : ViewItem<DashboardItemsModel, DashboardItemModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new DashboardItemsModel(await QueryRouter.Send(new GetDashboardItems()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.DashboardItems.Single(dashboardItem => dashboardItem.Id == id);
        var viewModel = new DashboardItemEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveDashboardItem(viewModel));

        ViewModel.DashboardItems.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(DashboardItemModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.Description.Contains(search, StringComparison.OrdinalIgnoreCase);
}
