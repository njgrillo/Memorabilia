namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class AutographWritingInstrumentPieChart : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        DashboardChartModel model = await Mediator.Send(new GetWritingInstrumentData());

        Data = model.Data;
        Labels = model.Labels;
    }
}
