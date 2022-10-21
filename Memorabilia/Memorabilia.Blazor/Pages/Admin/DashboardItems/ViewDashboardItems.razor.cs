using DashboardItemViewModel = Memorabilia.Application.Features.Admin.DashboardItems.DashboardItemViewModel;

namespace Memorabilia.Blazor.Pages.Admin.DashboardItems;

public partial class ViewDashboardItems : ViewItem<DashboardItemsViewModel, DashboardItemViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetDashboardItems());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.DashboardItems.Single(dashboardItem => dashboardItem.Id == id);
        var viewModel = new SaveDashboardItemViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveDashboardItem(viewModel));

        ViewModel.DashboardItems.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(DashboardItemViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Description.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
