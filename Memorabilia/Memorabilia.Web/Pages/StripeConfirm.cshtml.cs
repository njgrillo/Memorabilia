namespace Memorabilia.Web.Pages;

public class StripeConfirmModel : PageModel
{
    public void OnGet()
    {
        string orderId = Request.Query["OrderId"];

        Response.Redirect($"{NavigationPath.StripeOrderConfirm}/{orderId}");
    }
}
