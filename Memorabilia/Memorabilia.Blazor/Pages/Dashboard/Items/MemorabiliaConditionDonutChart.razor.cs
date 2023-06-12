﻿namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class MemorabiliaConditionDonutChart : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        DashboardChartModel model = await Mediator.Send(new GetMemorabiliaConditionData(UserId));

        Data = model.Data;
        Labels = model.Labels;
    }
}
