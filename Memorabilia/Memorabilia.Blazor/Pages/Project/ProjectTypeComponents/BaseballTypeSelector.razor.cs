namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class BaseballTypeSelector
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int BaseballTypeId { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter] 
    public EventCallback<Dictionary<string, object>> ProjectDetailsSet { get; set; }

    [Parameter]
    public int? TeamId { get; set; }

    [Parameter]
    public int? Year { get; set; }

    protected BaseballType BaseballType
        => BaseballTypeId > 0
        ? BaseballType.Find(BaseballTypeId)
        : null;

    protected bool IsTeam
        => BaseballType != null
        && BaseballType == BaseballType.TeamAnniversary;

    protected bool IsYearly
        => BaseballType != null
        && ((BaseballType?.IsYearly() ?? false)
            || (BaseballType?.CanImportByYearRange() ?? false));

    protected TeamEditModel Team { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (!TeamId.HasValue)
            return;

        var team = new TeamModel(await QueryRouter.Send(new GetTeam(TeamId.Value)));

        Team = new TeamEditModel(team);
    }

    protected async Task BaseballTypeChanged(int baseballTypeId)
    {
        BaseballTypeId = baseballTypeId;

        await OnParameterChanged();
    }

    protected async Task TeamChanged(TeamEditModel team)
    {
        Team = team;

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
            { "BaseballTypeId", BaseballTypeId },
        };

        if (Team != null)
            parameters.Add("TeamId", Team.Id);

        if (Year.HasValue)
            parameters.Add("Year", Year);

        await ProjectDetailsSet.InvokeAsync(parameters);
    }
}
