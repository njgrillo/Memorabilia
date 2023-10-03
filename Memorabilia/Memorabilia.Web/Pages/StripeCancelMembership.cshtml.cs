namespace Memorabilia.Web.Pages;

public class StripeCancelMembershipModel : PageModel
{
    public void OnGet()
    {
        string orderId = Request.Query["OrderId"];
        string userId = Request.Query["UserId"];

        Response.Redirect($"{NavigationPath.StripeOrderCancel}/{orderId}/{userId}");
    }
}
