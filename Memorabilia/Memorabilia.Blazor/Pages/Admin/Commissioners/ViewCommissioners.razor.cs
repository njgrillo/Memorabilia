#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Commissioners;

public partial class ViewCommissioners : ViewItem<CommissionersViewModel, CommissionerViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetCommissioners());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Commissioners.Single(Commissioner => Commissioner.Id == id);
        var viewModel = new SaveCommissionerViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveCommissioner(viewModel));

        ViewModel.Commissioners.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(CommissionerViewModel viewModel, string search)
    {
        var isYear = int.TryParse(search, out var year);

        return search.IsNullOrEmpty() ||
               viewModel.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (isYear && viewModel?.BeginYear == year) ||
               (isYear && viewModel?.EndYear == year) ||
               (viewModel.Person != null &&
                viewModel.Person.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
