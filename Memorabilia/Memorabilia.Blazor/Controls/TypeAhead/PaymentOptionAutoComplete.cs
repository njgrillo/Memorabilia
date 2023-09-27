namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PaymentOptionAutoComplete : DomainEntityAutoComplete<PaymentOption>
{
    protected override void OnInitialized()
    {
        AdornmentIcon = string.Empty;
        Label = "Payment Type";
        Placeholder = "Search by payment type...";
        Items = PaymentOption.All;
    }
}
