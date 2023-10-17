namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class TeamSelector
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public EventCallback<Dictionary<string, object>> ProjectDetailsSet { get; set; }

    [Parameter]
    public int TeamId { get; set; }

    [Parameter]
    public int? Year { get; set; }

    protected TeamEditModel SelectedTeam { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (TeamId == 0)
            return;

        var team = new TeamModel(await Mediator.Send(new GetTeam(TeamId)));

        SelectedTeam = new TeamEditModel(team);
    }

    protected async Task TeamChanged(TeamEditModel team)
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
