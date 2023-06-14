﻿namespace Memorabilia.Blazor.Pages.Dashboard.Items;

public partial class ItemTypeDonutChart : DashboardChartItem
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        DashboardChartModel model = await Mediator.Send(new GetItemTypeData());

        Data = model.Data;
        Labels = model.Labels;
    }
}
