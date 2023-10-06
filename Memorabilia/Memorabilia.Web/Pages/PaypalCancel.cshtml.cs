namespace Memorabilia.Web.Pages;

public class PaypalCancelModel : PageModel
{
    public void OnGet()
    {
        string orderId = Request.Query["OrderId"];

        Response.Redirect($"/Paypal/Order/Cancel/{orderId}");
    }
}
