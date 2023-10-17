namespace Memorabilia.Blazor.Models.PaypalClient;

public class CreateOrderResponse
{
    public string id { get; set; }

    public List<Link> links { get; set; }

    public string status { get; set; }    
}
