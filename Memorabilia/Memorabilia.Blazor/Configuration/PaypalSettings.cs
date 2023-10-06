namespace Memorabilia.Blazor.Configuration;

public class PaypalSettings : IPaypalSettings
{
    public string BaseUrl 
        => Mode == "Live"
            ? "https://api-m.paypal.com"
            : "https://api-m.sandbox.paypal.com";

    public string ClientSecret { get; set; }

    public string ClientId { get; set; }

    public string Mode { get; set; }   
}
