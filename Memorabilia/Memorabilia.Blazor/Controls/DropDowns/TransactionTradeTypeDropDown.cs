namespace Memorabilia.Blazor.Controls.DropDowns;

public class TransactionTradeTypeDropDown : DropDown<TransactionTradeType, int>
{
    protected override void OnInitialized()
    {
        Items = TransactionTradeType.All;
        Label = "Transaction Trade Type";
    }
}
