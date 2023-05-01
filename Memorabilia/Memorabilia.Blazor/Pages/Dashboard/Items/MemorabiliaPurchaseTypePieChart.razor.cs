namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class MemorabiliaPurchaseTypePieChart : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var viewModel = await Mediator.Send(new GetMemorabiliaPurchaseTypeData(UserId));

        Data = viewModel.Data;
        Labels = viewModel.Labels;
    }
}
