namespace Memorabilia.Blazor.Controls.DropDowns;

public class TransactionTypeDropDown : DropDown<TransactionType, int>
{
    protected override void OnInitialized()
    {
        Items = TransactionType.All;
        Label = "Transaction Type";
    }
}
