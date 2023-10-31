namespace Memorabilia.Blazor.Pages.PrivateSigning.SiteWide;

public partial class ViewPrivateSignings
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected PrivateSigningsModel Model
        = new();

    private bool _resetPaging;

    private MudTable<PrivateSigningModel> _table
       = new();

    protected override async Task OnInitializedAsync()
    {
        _resetPaging = true;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected async Task<TableData<PrivateSigningModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetPrivateSignings(pageInfo));

        return new TableData<PrivateSigningModel>()
        {
            Items = Model.PrivateSignings,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    private void ToggleChildContent(int privateSigningId)
    {
        PrivateSigningModel privateSigning
            = Model.PrivateSignings.Single(item => item.Id == privateSigningId);

        privateSigning.DisplayDetails = !privateSigning.DisplayDetails;
        privateSigning.ToggleIcon = privateSigning.DisplayDetails
            ? Icons.Material.Filled.ExpandLess
            : Icons.Material.Filled.ExpandMore;
    }
}
