namespace Memorabilia.Web.Pages;

public class PaypalConfirmModel : PageModel
{
    public void OnGet()
    {
        string orderId = Request.Query["OrderId"];

        Response.Redirect($"/Paypal/Order/Confirm/{orderId}");
    }
}
