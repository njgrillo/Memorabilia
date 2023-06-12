namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class CostDonutChart : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        DashboardChartModel model = await Mediator.Send(new GetCostData(UserId));

        Data = model.Data;
        Labels = model.Labels;
    }
}
