using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Stripe;

public partial class ConfirmMembershipStripeOrder
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public StripeService StripeService { get; set; }

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

        var subscription =
            await StripeService.GetSubscriptionByCustomerAsync(ApplicationStateService.CurrentUser.StripeCustomerId);

        if (subscription != null)
        {
            EditModel.ActivateSubscription(subscriptionId: subscription.Id);
        }
        else
        {
            EditModel.ActivateSubscription(expirationDate: DateTime.UtcNow.AddMonths(1));
        }

        await Mediator.Send(new SaveUser(EditModel));

        await Mediator.Publish(new UserSubscriptionChangedNotification());
    }
}
