namespace Memorabilia.Blazor.Pages.Transaction;

public partial class PartialTradesEditGrid
{
    [Parameter]
    public List<MemorabiliaTransactionTradeEditModel> PartialTrades { get; set; }
        = new();

    private MemorabiliaTransactionTradeEditModel _elementBeforeEdit;

    private void BackupItem(object element)
    {
        _elementBeforeEdit = new()
        {
            CashIncludedAmount = ((MemorabiliaTransactionTradeEditModel)element).CashIncludedAmount,
            CashIncludedTypeId = ((MemorabiliaTransactionTradeEditModel)element).CashIncludedTypeId,
            TransactionTradeTypeId = ((MemorabiliaTransactionTradeEditModel)element).TransactionTradeTypeId
        };
    }

    protected void OnImageLoaded()
    {
        StateHasChanged();
    }

    private void ResetItemToOriginalValues(object element)
    {
        ((MemorabiliaTransactionTradeEditModel)element).CashIncludedAmount = _elementBeforeEdit.CashIncludedAmount;
        ((MemorabiliaTransactionTradeEditModel)element).CashIncludedTypeId = _elementBeforeEdit.CashIncludedTypeId;
        ((MemorabiliaTransactionTradeEditModel)element).TransactionTradeTypeId = _elementBeforeEdit.TransactionTradeTypeId;
    }

    private void UpdatePartialTrade(object element)
    {
        StateHasChanged();
    }
}
