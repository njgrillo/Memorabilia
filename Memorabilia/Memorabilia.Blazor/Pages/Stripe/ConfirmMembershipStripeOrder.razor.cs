namespace Memorabilia.Blazor.Pages.Stripe;

public partial class ConfirmMembershipStripeOrder
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Parameter]
    public string EncryptOrderId { get; set; }

    [Parameter]
    public string EncryptRoleId { get; set; }

    [Parameter]
    public string EncryptUserId { get; set; }

    protected UserEditModel EditModel { get; set; }
        = new();

    protected string OrderId { get; set; }

    protected int UserId { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (EncryptRoleId.IsNullOrEmpty())
            return;

        OrderId = DataProtectorService.Decrypt(EncryptOrderId);
        UserId = DataProtectorService.DecryptId(EncryptUserId);

        var userRole = new UserRoleEditModel
        {
            RoleId = DataProtectorService.DecryptId(EncryptRoleId),
            UserId = UserId
        };

        EditModel.Id = UserId;
        EditModel.UserRole = userRole;

        await CommandRouter.Send(new SaveUser(EditModel));
    }
}
