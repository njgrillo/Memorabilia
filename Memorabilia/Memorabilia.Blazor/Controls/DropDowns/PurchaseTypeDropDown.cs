namespace Memorabilia.Blazor.Controls.DropDowns;

public class PurchaseTypeDropDown : DropDown<PurchaseType, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = PurchaseType.All;
        Label = "Purchase Type";
    }
}
