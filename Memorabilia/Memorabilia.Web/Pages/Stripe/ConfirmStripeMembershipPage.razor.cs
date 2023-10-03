namespace Memorabilia.Web.Pages.Stripe;

public partial class ConfirmStripeMembershipPage
{
    [Parameter]
    public string OrderId { get; set; }

    [Parameter]
    public string RoleId { get; set; }

    [Parameter]
    public string UserId { get; set; }
}
