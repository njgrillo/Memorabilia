namespace Memorabilia.Blazor.Pages.Admin.Commissioners;

public partial class ViewCommissioners : ViewItem<CommissionersModel, CommissionerModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new CommissionersModel(await QueryRouter.Send(new GetCommissioners()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Commissioners.Single(Commissioner => Commissioner.Id == id);
        var viewModel = new CommissionerEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveCommissioner(viewModel));

        ViewModel.Commissioners.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(CommissionerModel viewModel, string search)
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
