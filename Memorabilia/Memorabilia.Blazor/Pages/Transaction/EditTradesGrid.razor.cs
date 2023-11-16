using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Transaction;

public partial class EditTradesGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Parameter]
    public List<MemorabiliaTransactionTradeEditModel> Trades { get; set; }
        = [];

    private MemorabiliaTransactionTradeEditModel _elementBeforeEdit;

    private void BackupItem(object element)
    {
        _elementBeforeEdit = new()
        {
            TransactionTradeTypeId = ((MemorabiliaTransactionTradeEditModel)element).TransactionTradeTypeId
        };
    }

    private void ResetItemToOriginalValues(object element)
    {
        ((MemorabiliaTransactionTradeEditModel)element).TransactionTradeTypeId = _elementBeforeEdit.TransactionTradeTypeId;
    }
}
