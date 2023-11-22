namespace Memorabilia.Blazor.Pages.ThroughTheMail;

public partial class SentThroughTheMailGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }    

    protected ThroughTheMailsModel Model { get; set; }
        = new();

    protected string Search { get; set; }

    private bool _resetPaging;

    private MudTable<ThroughTheMailModel> _table
       = new();

    protected override async Task OnInitializedAsync()
    {
        _resetPaging = true;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected async Task Delete(int id)
    {
        ThroughTheMailModel deletedItem
            = Model.Items.Single(throughTheMail => throughTheMail.Id == id);

        var model = new ThroughTheMailEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveThroughTheMail.Command(model));

        Model.Items.Remove(deletedItem);

        Snackbar.Add("TTM was deleted successfully!", Severity.Success);
    }

    protected bool Filter(ThroughTheMailModel model)
    {
        bool dateSearch = DateTime.TryParse(Search, out DateTime date);

        return Search.IsNullOrEmpty() ||
               (dateSearch && (model.SentDate == date || model.ReceivedDate == date)) ||
               string.Equals(model.Status, Search, StringComparison.OrdinalIgnoreCase) ||
               PersonFilterService.Filter(model.Person, Search);
    }

    protected ThroughTheMailMemorabiliaModel[] GetThroughTheMailMemorabiliaModels(int throughTheMailId)
        => Model.Items
                .Single(item => item.Id == throughTheMailId)
                .Memorabilia
                .Select(memorabilia => new ThroughTheMailMemorabiliaModel(memorabilia))
                .ToArray();

    protected void Navigate(string path)
    {
        NavigationManager.NavigateTo(path);
    }

    protected async Task<TableData<ThroughTheMailModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetSentThroughTheMails(pageInfo));

        return new TableData<ThroughTheMailModel>()
        {
            Items = Model.Items,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    private void ToggleChildContent(int throughTheMailId)
    {
        ThroughTheMailModel throughTheMail = Model.Items.Single(item => item.Id == throughTheMailId);

        throughTheMail.DisplayMemorabiliaDetails = !throughTheMail.DisplayMemorabiliaDetails;
    }
}
