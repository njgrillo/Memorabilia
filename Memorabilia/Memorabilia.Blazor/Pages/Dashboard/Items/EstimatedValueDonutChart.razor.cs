﻿namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class EstimatedValueDonutChart : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        DashboardChartModel model = await Mediator.Send(new GetEstimatedValueData(UserId));

        Data = model.Data;
        Labels = model.Labels;
    }
}
