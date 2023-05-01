namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class ColorDonutChart : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var viewModel = await Mediator.Send(new GetColorData(UserId));

        Data = viewModel.Data;
        Labels = viewModel.Labels;
    }
}
