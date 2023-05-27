namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class WorldSeriesSelector
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public int? ItemTypeId { get; set; }

    [Parameter]
    public EventCallback<Dictionary<string, object>> ProjectDetailsSet { get; set; }

    [Parameter]
    public int TeamId { get; set; }

    [Parameter]
    public int? Year { get; set; }

    protected Domain.Constants.ItemType ItemType { get; set; }    

    protected SaveTeamViewModel Team { get; set; }

    protected override async Task OnInitializedAsync()
    {
        TeamViewModel team = await QueryRouter.Send(new GetTeam(TeamId));

        Team = new SaveTeamViewModel(team);

        if (ItemTypeId.HasValue)
            ItemType = Domain.Constants.ItemType.Find(ItemType.Value);
    }

    protected async Task ItemTypeChanged(Domain.Constants.ItemType itemType)
    {
        ItemType = itemType;

        await OnParameterChanged();
    }

    protected async Task TeamChanged(SaveTeamViewModel team)
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
            { "TeamId", Team.Id },
        };

        if (ItemTypeId.HasValue)
            parameters.Add("ItemTypeId", ItemTypeId);

        if (Year.HasValue)
            parameters.Add("Year", Year);

        await ProjectDetailsSet.InvokeAsync(parameters);
    }
}
