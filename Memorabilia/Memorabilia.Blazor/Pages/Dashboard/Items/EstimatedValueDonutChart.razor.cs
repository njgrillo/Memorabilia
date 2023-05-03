namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class EstimatedValueDonutChart : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var viewModel = await Mediator.Send(new GetEstimatedValueData(UserId));

        Data = viewModel.Data;
        Labels = viewModel.Labels;
    }
}
