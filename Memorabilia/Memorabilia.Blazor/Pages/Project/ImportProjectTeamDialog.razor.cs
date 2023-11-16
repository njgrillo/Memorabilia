using Memorabilia.Application.Services.Filters;

namespace Memorabilia.Blazor.Pages.Project;

public partial class ImportProjectTeamDialog
{
    [Inject]
    public IMediator Mediator { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    private bool Filter(Entity.Team team)
        => TeamFilterService.Filter(team, _search);

    protected Entity.Team[] Teams { get; set; } 
        = [];

    private string _search;

    private string SelectAllButtonText
        => Teams != null && Teams.Length == SelectedTeams.Count
            ? "Deselect All"
            : "Select All";

    private List<Entity.Team> SelectedTeams 
        = [];

    protected override async Task OnInitializedAsync()
    {
        Teams = await Mediator.Send(new GetProjectTeams(SportId: Sport.Football.Id));
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    public void Import()
    {
        MudDialog.Close(DialogResult.Ok(SelectedTeams.ToArray()));
    }

    protected void OnSelectAll()
    {
        SelectedTeams = Teams.Length == SelectedTeams.Count
            ? []
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
