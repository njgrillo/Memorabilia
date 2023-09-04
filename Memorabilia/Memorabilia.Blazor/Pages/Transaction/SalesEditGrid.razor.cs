namespace Memorabilia.Blazor.Pages.Transaction;

public partial class SalesEditGrid
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Parameter]
    public List<MemorabiliaTransactionSaleEditModel> Sales { get; set; }
        = new();

    private MemorabiliaTransactionSaleEditModel _elementBeforeEdit;

    private void BackupItem(object element)
    {
        _elementBeforeEdit = new()
        {
            SaleAmount = ((MemorabiliaTransactionSaleEditModel)element).SaleAmount
        };
    }

    protected void OnImageLoaded()
    {
        StateHasChanged();
    }

    private void ResetItemToOriginalValues(object element)
    {
        ((MemorabiliaTransactionSaleEditModel)element).SaleAmount = _elementBeforeEdit.SaleAmount;
    }

    private void UpdateSaleAmount(object element)
    {
        StateHasChanged();
    }
}
