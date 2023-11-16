using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.UserMessage;

public partial class UserMessageInboxGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public string SearchText { get; set; }

    [Parameter]
    public List<UserMessageModel> SelectedUserMessages { get; set; }
        = [];

    [Parameter]
    public EventCallback<List<UserMessageModel>> UserMessagesSelected { get; set; }

    protected UserMessagesModel Model { get; set; }
        = new();

    protected string SelectAllButtonText
        => Model.Messages.Count == SelectedUserMessages.Count
           ? "Deselect All"
           : "Select All";

    private bool _isInitialLoad
        = true;

    private bool _resetPaging;
    private string _searchText;

    private MudTable<UserMessageModel> _table
        = new();

    protected override async Task OnInitializedAsync()
    {
        if (!_isInitialLoad)
            return;

        await _table.ReloadServerData();        
    }

    protected override async Task OnParametersSetAsync()
    {
        if (_searchText == SearchText)
            return;

        _resetPaging = true;
        _searchText = SearchText;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected async Task<TableData<UserMessageModel>> OnRead(TableState state)
    {
        var pageInfo = _isInitialLoad
            ? new PageInfo()
            : new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = _isInitialLoad
            ? await Mediator.Send(new GetUserMessagesReceived(pageInfo))
            : await Mediator.Send(new SearchUserMessagesReceived(pageInfo, SearchText));

        _isInitialLoad = false;

        return new TableData<UserMessageModel>()
        {
            Items = Model.Messages,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    protected async Task OnSelectAll()
    {
        SelectedUserMessages = Model.Messages.Count == SelectedUserMessages.Count
            ? []
            : Model.Messages.ToList();

        await UserMessagesSelected.InvokeAsync(SelectedUserMessages);
    }

    protected async Task OnUserMessageSelected(UserMessageModel item)
    {
        if (!SelectedUserMessages.Contains(item))
        {
            SelectedUserMessages.Add(item);

            await UserMessagesSelected.InvokeAsync(SelectedUserMessages);

            return;
        }

        SelectedUserMessages.Remove(item);

        await UserMessagesSelected.InvokeAsync(SelectedUserMessages);
    }

    protected async Task DeleteMessage(int id)
    {
        UserMessageModel itemToDelete 
            = Model.Messages.Single(message => message.Id == id);
        
        await Mediator.Send(new UpdateUserMessageStatus(id, UserMessageStatus.Deleted.Id));

        Model.Messages.Remove(itemToDelete);

        Snackbar.Add($"Message was deleted successfully!", Severity.Success);
    }

    protected async Task ShowDeleteConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Delete Message");
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await DeleteMessage(id);
    }

    private void ToggleChildContent(int userMessageId)
    {
        UserMessageModel message = Model.Messages.Single(item => item.Id == userMessageId);

        message.DisplayReplies = !message.DisplayReplies;
    }
}
