namespace Memorabilia.Blazor.Models.PaypalClient;

public class Capture
{
    public Amount amount { get; set; }

    public DateTime create_time { get; set; }

    public bool final_capture { get; set; }

    public string disbursement_mode { get; set; }

    public string id { get; set; }

    public List<Link> links { get; set; }

    public SellerProtection seller_protection { get; set; }

    public SellerReceivableBreakdown seller_receivable_breakdown { get; set; }

    public string status { get; set; }

    public DateTime update_time { get; set; } 
}
