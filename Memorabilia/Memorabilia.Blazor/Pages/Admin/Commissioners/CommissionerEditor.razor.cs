namespace Memorabilia.Blazor.Pages.Admin.Commissioners;

public partial class CommissionerEditor : EditItem<SaveCommissionerViewModel, CommissionerViewModel>
{
    private IEnumerable<PersonViewModel> People = Enumerable.Empty<PersonViewModel>();

    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveCommissioner(ViewModel));
    }

    protected async Task OnLoad()
    {
        await LoadPeople();

        if (Id == 0)
            return;

        ViewModel = new SaveCommissionerViewModel(await Get(new GetCommissioner(Id)));
    }

    private async Task LoadPeople()
    {
        People = (await QueryRouter.Send(new GetPeople())).People;
    }

    private async Task<IEnumerable<PersonViewModel>> SearchPeople(string searchText)
    {
        if (searchText.IsNullOrEmpty())
            return Array.Empty<PersonViewModel>();

        return await Task.FromResult(People.Where(person => person.DisplayName.Contains(searchText, StringComparison.OrdinalIgnoreCase)));
    }
}
