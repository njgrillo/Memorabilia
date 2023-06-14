namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class SpotPieChart : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        DashboardChartModel model = await Mediator.Send(new GetSpotData());

        Data = model.Data;
        Labels = model.Labels;
    }
}
