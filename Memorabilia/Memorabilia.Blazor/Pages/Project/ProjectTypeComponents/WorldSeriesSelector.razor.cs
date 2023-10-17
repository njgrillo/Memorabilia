namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class WorldSeriesSelector
{
    [Inject]
    public IMediator Mediator { get; set; }

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

    protected ItemType ItemType { get; set; }    

    protected TeamEditModel Team { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (TeamId == 0)
            return;

        var team = new TeamModel(await Mediator.Send(new GetTeam(TeamId)));

        Team = new TeamEditModel(team);

        if (ItemTypeId.HasValue)
            ItemType = ItemType.Find(ItemType.Value);
    }

    protected async Task ItemTypeChanged(ItemType itemType)
    {
        ItemType = itemType;

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
            { "TeamId", Team.Id },
        };

        if (ItemTypeId.HasValue)
            parameters.Add("ItemTypeId", ItemTypeId);

        if (Year.HasValue)
            parameters.Add("Year", Year);

        await ProjectDetailsSet.InvokeAsync(parameters);
    }
}
