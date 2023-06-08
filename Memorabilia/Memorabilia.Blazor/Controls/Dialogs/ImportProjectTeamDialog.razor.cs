namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class ImportProjectTeamDialog
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    private bool FilterFunc1(Entity.Team team)
        => FilterFunc(team, _search);

    protected Entity.Team[] Teams { get; set; } 
        = Array.Empty<Entity.Team>();

    private string _search;

    private string SelectAllButtonText
        => Teams != null && Teams.Length == SelectedTeams.Count
            ? "Deselect All"
            : "Select All";

    private List<Entity.Team> SelectedTeams = new();

    protected override async Task OnInitializedAsync()
    {
        Teams = await QueryRouter.Send(new GetProjectTeams(SportId: Sport.Football.Id));
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    protected static bool FilterFunc(Entity.Team team, string search)
        => search.IsNullOrEmpty() ||
           team.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           team.Location.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           team.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           team.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           team.Franchise.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           team.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase);

    public void Import()
    {
        MudDialog.Close(DialogResult.Ok(SelectedTeams.ToArray()));
    }

    protected void OnSelectAll()
    {
        SelectedTeams = Teams.Length == SelectedTeams.Count
            ? new()
            : Teams.ToList();
    }

    protected void TeamSelected(Entity.Team team)
    {
        if (!SelectedTeams.Contains(team))
        {
            SelectedTeams.Add(team);
            return;
        }

        SelectedTeams.Remove(team);
    }
}
