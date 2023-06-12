namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class SportPieChart : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        DashboardChartModel model = await Mediator.Send(new GetSportData(UserId));

        Data = model.Data;
        Labels = model.Labels;
    }
}
