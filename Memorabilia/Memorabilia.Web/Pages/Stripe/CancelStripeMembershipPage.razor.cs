namespace Memorabilia.Web.Pages.Stripe;

public partial class CancelStripeMembershipPage
{
    [Parameter]
    public string OrderId { get; set; }

    [Parameter]
    public string UserId { get; set; }
}
