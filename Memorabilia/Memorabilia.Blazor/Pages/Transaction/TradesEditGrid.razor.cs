namespace Memorabilia.Blazor.Pages.Transaction;

public partial class TradesEditGrid
{
    [Parameter]
    public List<MemorabiliaTransactionTradeEditModel> Trades { get; set; }
        = new();

    private MemorabiliaTransactionTradeEditModel _elementBeforeEdit;

    private void BackupItem(object element)
    {
        _elementBeforeEdit = new()
        {
            TransactionTradeTypeId = ((MemorabiliaTransactionTradeEditModel)element).TransactionTradeTypeId
        };
    }

    protected void OnImageLoaded()
    {
        StateHasChanged();
    }

    private void ResetItemToOriginalValues(object element)
    {
        ((MemorabiliaTransactionTradeEditModel)element).TransactionTradeTypeId = _elementBeforeEdit.TransactionTradeTypeId;
    }

    private void UpdateTrade(object element)
    {
        StateHasChanged();
    }
}
