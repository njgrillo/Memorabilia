namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class FranchiseDonutChart : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        DashboardChartModel model = await Mediator.Send(new GetFranchiseData());

        Data = model.Data;
        Labels = model.Labels;
    }
}
