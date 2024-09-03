namespace Memorabilia.Blazor.Pages.MemorabiliaItems.History;

public partial class MemorabiliaHistoryGrid
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public int MemorabiliaId { get; set; }

    private MemorabiliaItemHistoriesModel Model 
        = new();

    protected async Task<TableData<MemorabiliaItemHistoryModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetMemorabiliaItemHistoriesPaged(MemorabiliaId, pageInfo));

        return new TableData<MemorabiliaItemHistoryModel>()
        {
            Items = Model.HistoryItems,
            TotalItems = Model.PageInfo.TotalItems
        };
    }
}
