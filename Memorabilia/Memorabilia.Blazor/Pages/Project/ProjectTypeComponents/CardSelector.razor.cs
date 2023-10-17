namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class CardSelector
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public int BrandId { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public EventCallback<Dictionary<string, object>> ProjectDetailsSet { get; set; }

    [Parameter]
    public int? TeamId { get; set; }

    [Parameter]
    public int? Year { get; set; }

    protected Brand Brand { get; set; }

    protected TeamEditModel Team { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Brand = Brand.Find(BrandId);

        if (TeamId.HasValue)
        {
            var team = new TeamModel(await Mediator.Send(new GetTeam(TeamId.Value)));

            Team = new TeamEditModel(team);
        }        
    }

    protected async Task BrandChanged(Brand brand)
    {
        Brand = brand;

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
            { "BrandId", Brand.Id },
        };

        if (Team != null)
            parameters.Add("TeamId", Team.Id);

        if (Year.HasValue)
            parameters.Add("Year", Year);

        await ProjectDetailsSet.InvokeAsync(parameters);
    }
}
