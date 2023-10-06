namespace Memorabilia.Web.Pages;

public class StripeCancelModel : PageModel
{
    public void OnGet()
    {
        string orderId = Request.Query["OrderId"];

        Response.Redirect($"{NavigationPath.StripeOrderCancel}/{orderId}");
    }
}
