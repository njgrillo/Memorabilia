namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class AutographAcquisitionTypeDonutChart 
    : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        DashboardChartModel model = await Mediator.Send(new GetAutographAcquisitionData(UserId));

        Data = model.Data;
        Labels = model.Labels;
    }
}
