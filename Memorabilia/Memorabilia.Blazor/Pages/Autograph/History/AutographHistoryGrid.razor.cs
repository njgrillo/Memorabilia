namespace Memorabilia.Blazor.Pages.Autograph.History;

public partial class AutographHistoryGrid
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public int AutographId { get; set; }

    private AutographHistoriesModel Model
        = new();

    protected async Task<TableData<AutographHistoryModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetAutographHistoriesPaged(AutographId, pageInfo));

        return new TableData<AutographHistoryModel>()
        {
            Items = Model.HistoryItems,
            TotalItems = Model.PageInfo.TotalItems
        };
    }
}
