namespace Memorabilia.Blazor.Pages.Transaction;

public partial class EditSalesGrid

{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Parameter]
    public List<MemorabiliaTransactionSaleEditModel> Sales { get; set; }
        = [];

    private MemorabiliaTransactionSaleEditModel _elementBeforeEdit;

    private void BackupItem(object element)
    {
        _elementBeforeEdit = new()
        {
            SaleAmount = ((MemorabiliaTransactionSaleEditModel)element).SaleAmount
        };
    }

    private void ResetItemToOriginalValues(object element)
    {
        ((MemorabiliaTransactionSaleEditModel)element).SaleAmount = _elementBeforeEdit.SaleAmount;
    }
}
