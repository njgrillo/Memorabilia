namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class BrandDonutChart : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        DashboardChartModel model = await Mediator.Send(new GetBrandData(UserId));

        Data = model.Data;
        Labels = model.Labels;
    }
}


