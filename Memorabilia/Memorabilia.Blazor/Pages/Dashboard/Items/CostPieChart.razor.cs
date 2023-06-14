namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class CostPieChart : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        DashboardChartModel model = await Mediator.Send(new GetCostData());

        Data = model.Data;
        Labels = model.Labels;
    }
}
