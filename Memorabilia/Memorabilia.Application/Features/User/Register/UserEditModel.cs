namespace Memorabilia.Application.Features.User.Register;

public class UserEditModel : EditModel
{
    public UserEditModel() { }

    public UserEditModel(Entity.User user)
    {        
        FirstName = user.FirstName;
        Id = user.Id;
        LastName = user.LastName;        
        StripeCustomerId = user.StripeCustomerId;
        StripeSubscriptionId = user.StripeSubscriptionId;
        SubscriptionCanceled = user.SubscriptionCanceled;
        UserRole = new UserRoleEditModel(user.Roles.FirstOrDefault());

        if (user.UserSettings?.ShippingAddress != null)
            ShippingAddress = new(user.UserSettings.ShippingAddress);
    }   

    public string EmailAddress { get; set; }

    public string FirstName { get; set; }

    public string GoogleEmailAddress { get; set; }

    public string LastName { get; set; }

    public string MicrosoftEmailAddress { get; set; }

    public AddressEditModel ShippingAddress { get; set; }
        = new();

    public string StripeCustomerId { get; set; }

    public string StripeSubscriptionId { get; set; }

    public bool SubscriptionCanceled { get; set; }

    public DateTime? SubscriptionExpirationDate { get; set; }

    public string Username { get; set; }

    public UserRoleEditModel UserRole { get; set; }
        = new();

    public string XHandle { get; set; }

    public void ActivateSubscription(DateTime? expirationDate = null, string subscriptionId = null)
    {
        StripeSubscriptionId = subscriptionId;
        SubscriptionCanceled = false;
        SubscriptionExpirationDate = expirationDate; 
    }

    public void CancelSubscription(DateTime? expirationDate)
    {
        SubscriptionCanceled = true;
        SubscriptionExpirationDate = expirationDate;
    }
}
