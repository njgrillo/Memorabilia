namespace Memorabilia.Web.Pages;

public class StripeConfirmMembershipModel : PageModel
{
    public void OnGet()
    {
        string orderId = Request.Query["OrderId"];
        string roleId = Request.Query["RoleId"];        
        string userId = Request.Query["UserId"];        

        Response.Redirect($"{NavigationPath.StripeConfirmMembership}/{roleId}/{orderId}/{userId}");
    }
}
