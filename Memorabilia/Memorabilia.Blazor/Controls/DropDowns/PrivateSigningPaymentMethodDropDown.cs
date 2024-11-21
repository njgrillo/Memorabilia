namespace Memorabilia.Blazor.Controls.DropDowns;

public class PrivateSigningPaymentMethodDropDown : DropDown<PrivateSigningPaymentMethod, int>
{
    protected override void OnInitialized()
    {
        Items = PrivateSigningPaymentMethod.All;
        Label = "Method";
    }
}
