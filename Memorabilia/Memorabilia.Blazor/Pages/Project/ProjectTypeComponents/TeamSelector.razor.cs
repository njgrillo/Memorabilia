namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class TeamSelector
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public EventCallback<Dictionary<string, object>> ProjectDetailsSet { get; set; }

    [Parameter]
    public int TeamId { get; set; }

    [Parameter]
    public int? Year { get; set; }

    protected SaveTeamViewModel SelectedTeam { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (TeamId == 0)
            return;

        TeamViewModel team = await QueryRouter.Send(new GetTeam(TeamId));

        SelectedTeam = new SaveTeamViewModel(team);
    }

    protected async Task TeamChanged(SaveTeamViewModel team)
    {
        SelectedTeam = team;

        await OnParameterChanged();
    }

    protected async Task YearChanged(int? year)
    {
        Year = year;

        await OnParameterChanged();
    }

    private async Task OnParameterChanged()
    {
        var parameters = new Dictionary<string, object>
        {
            { "TeamId", SelectedTeam.Id }
        };

        if (Year.HasValue)
            parameters.Add("Year", Year);

        await ProjectDetailsSet.InvokeAsync(parameters);
    }
}
