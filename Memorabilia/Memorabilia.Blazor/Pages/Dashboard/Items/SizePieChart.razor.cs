namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class SizePieChart : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var viewModel = await Mediator.Send(new GetSizeData(UserId));

        Data = viewModel.Data;
        Labels = viewModel.Labels;
    }
}
