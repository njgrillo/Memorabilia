using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Transaction;

public partial class EditPartialTradesGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Parameter]
    public List<MemorabiliaTransactionTradeEditModel> PartialTrades { get; set; }
        = [];

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

    private void ResetItemToOriginalValues(object element)
    {
        ((MemorabiliaTransactionTradeEditModel)element).CashIncludedAmount = _elementBeforeEdit.CashIncludedAmount;
        ((MemorabiliaTransactionTradeEditModel)element).CashIncludedTypeId = _elementBeforeEdit.CashIncludedTypeId;
        ((MemorabiliaTransactionTradeEditModel)element).TransactionTradeTypeId = _elementBeforeEdit.TransactionTradeTypeId;
    }
}
