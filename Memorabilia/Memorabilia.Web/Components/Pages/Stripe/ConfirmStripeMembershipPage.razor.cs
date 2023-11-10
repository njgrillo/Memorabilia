namespace Memorabilia.Web.Components.Pages.Stripe;

public partial class ConfirmStripeMembershipPage
{
    [Parameter]
    public string OrderId { get; set; }

    [Parameter]
    public string RoleId { get; set; }

    [Parameter]
    public string UserId { get; set; }
}
