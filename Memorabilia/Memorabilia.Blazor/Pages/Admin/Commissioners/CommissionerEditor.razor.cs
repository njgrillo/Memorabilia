#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Commissioners;

public partial class CommissionerEditor : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private IEnumerable<PersonViewModel> People = Enumerable.Empty<PersonViewModel>();
    private SaveCommissionerViewModel ViewModel = new ();

    protected async Task HandleValidSubmit()
    {
        await CommandRouter.Send(new SaveCommissioner.Command(ViewModel)).ConfigureAwait(false);
    }

    protected async Task OnLoad()
    {
        await LoadPeople().ConfigureAwait(false);

        if (Id == 0)
            return;

        ViewModel = new SaveCommissionerViewModel(await QueryRouter.Send(new GetCommissioner.Query(Id)).ConfigureAwait(false));
    }

    private async Task LoadPeople()
    {
        People = (await QueryRouter.Send(new GetPeople.Query()).ConfigureAwait(false)).People;
    }

    private async Task<IEnumerable<PersonViewModel>> SearchPeople(string searchText)
    {
        if (searchText.IsNullOrEmpty())
            return Array.Empty<PersonViewModel>();

        return await Task.FromResult(People.Where(person => person.DisplayName.Contains(searchText, StringComparison.OrdinalIgnoreCase))).ConfigureAwait(false);
    }
}
