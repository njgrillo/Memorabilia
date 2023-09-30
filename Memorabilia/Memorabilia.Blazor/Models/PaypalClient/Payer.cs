namespace Memorabilia.Blazor.Models.PaypalClient;

public class Payer
{
    public string email_address { get; set; }

    public Name name { get; set; }
    
    public string payer_id { get; set; }
}
