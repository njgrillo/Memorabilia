using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Enums;

namespace Memorabilia.Domain.Entities;

public class User : Entity
{
    public User() { }

    public User(int id,
                string username)
    {
        Id = id;
        Username = username;    
    }

    public User(string emailAddress, 
                string firstName, 
                string lastName,
                string username)
    {
        EmailAddress = emailAddress;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        CreateDate = DateTime.UtcNow;

        Roles = new()
        {
            new UserRole(Constant.Role.NonSubscriber.Id, Id)
        };
    }

    public virtual List<ForumTopicUserBookmark> BookmarkedForumTopics { get; private set; }

    public DateTime CreateDate { get; private set; }    

    public virtual List<UserDashboard> DashboardItems { get; private set; }

    public string EmailAddress { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }   

    public virtual List<UserPaymentOption> PaymentOptions { get; private set; }

    public virtual List<PrivateSigningCustomItemGroup> PrivateSigningCustomItemGroups { get; private set; }

    public virtual List<PromoterPaymentOption> PromoterPaymentOptions { get; private set; }

    public virtual List<UserRole> Roles { get; private set; }

    public virtual List<UserSocialMedia> SocialMedias { get; private set; }

    public string StripeCustomerId { get; private set; }

    public string StripeSubscriptionId { get; private set; }

    public bool SubscriptionCanceled { get; private set; }

    public DateTime? SubscriptionExpirationDate { get; private set; }

    public DateTime? UpdateDate { get; private set; }

    public string Username { get; private set; }    

    public virtual UserSettings UserSettings { get; private set; }

    public void RemoveHomeBackgroundImageFileName()
    {
        if (UserSettings is null)
        {
            return;
        }

        UserSettings.RemoveHomeBackgroundImageFileName();
    }

    public void RemovePrivateSigningCustomItemGroups(int privateSigningCustomItemGroupId)
    {
        PrivateSigningCustomItemGroups ??= [];

        PrivateSigningCustomItemGroup privateSigningCustomItemGroup 
            = PrivateSigningCustomItemGroups.SingleOrDefault(x => x.Id == privateSigningCustomItemGroupId);

        if (privateSigningCustomItemGroup is null)
            return;

        privateSigningCustomItemGroup.Items.Clear();

        PrivateSigningCustomItemGroups.Remove(privateSigningCustomItemGroup);
    }

    public void RemovePrivateSigningCustomItemTypeGroups(
        int privateSigningCustomItemGroupId, 
        int[] privateSigningCustomItemTypeGroupIds
        )
    {
        PrivateSigningCustomItemGroups ??= [];

        PrivateSigningCustomItemGroup privateSigningCustomItemGroup
            = PrivateSigningCustomItemGroups.SingleOrDefault(x => x.Id == privateSigningCustomItemGroupId);

        if (privateSigningCustomItemGroup is null)
            return;

        privateSigningCustomItemGroup.RemoveItems(privateSigningCustomItemTypeGroupIds);
    }

    public void SetHomeBackgroundImageFileName(string fileName)
    {
        UserSettings ??= new();

        UserSettings.SetHomeBackgroundImageFileName(fileName);
    }

    public void SetDashboardItems(params int[] dashboardItemsIds)
    {
        if (dashboardItemsIds == null || dashboardItemsIds.Length == 0)
            DashboardItems = [];

        DashboardItems.RemoveAll(dashboardItem => !dashboardItemsIds.Contains(dashboardItem.DashboardItemId));
        DashboardItems.AddRange(dashboardItemsIds.Where(dashboardItemsId => !DashboardItems.Select(dashboardItemId => dashboardItemId.DashboardItemId)
                                                                                           .Contains(dashboardItemsId))
                                                 .Select(dashboardItemsId => new UserDashboard(Id, dashboardItemsId)));
    }

    public void SetPaymentOption(int userPaymentOptionId,
                                 int paymentOptionId, 
                                 string paymentHandle,
                                 PaymentOptionType paymentOptionType)
    {
        if (PaymentOptions == null)
        {
            PaymentOptions =
            [
                new UserPaymentOption(Id, paymentOptionId, paymentHandle, paymentOptionType)
            ];

            return;
        }

        UserPaymentOption paymentOption 
            = userPaymentOptionId > 0 
                ? PaymentOptions.Single(paymentOption => paymentOption.Id == userPaymentOptionId)
                : null;

        if (paymentOption == null)
        {
            PaymentOptions.Add(new UserPaymentOption(Id, paymentOptionId, paymentHandle, paymentOptionType));

            return;
        }

        paymentOption.Set(paymentHandle, paymentOptionType);
    }

    public void SetPrivateSigningCustomItemGroups(
        int privateSigningCustomItemGroupId,
        string name,
        PrivateSigningCustomItemTypeGroup[] privateSigningCustomItemTypeGroups
        )
    {
        PrivateSigningCustomItemGroups ??= [];

        PrivateSigningCustomItemGroup privateSigningCustomItemGroup
            = privateSigningCustomItemGroupId > 0
                ? PrivateSigningCustomItemGroups.Single(group => group.Id == privateSigningCustomItemGroupId)
                : null;

        if (privateSigningCustomItemGroup is null)
        {
            PrivateSigningCustomItemGroups.Add(new PrivateSigningCustomItemGroup(Id, name, privateSigningCustomItemTypeGroups));
            return;
        }

        privateSigningCustomItemGroup.Set(name, privateSigningCustomItemTypeGroups);
    }

    public void SetPromoterPaymentOption(
        int promoterPaymentOptionId, 
        int privateSigningPaymentMethodId,
        string paymentMethodHandle
        )
    {
        if (PromoterPaymentOptions == null)
        {
            PromoterPaymentOptions =
            [
                new PromoterPaymentOption(privateSigningPaymentMethodId, paymentMethodHandle, Id)
            ];

            return;
        }

        PromoterPaymentOption paymentOption
            = promoterPaymentOptionId > 0
                ? PromoterPaymentOptions.Single(option => option.Id == promoterPaymentOptionId)
                : null;

        if (paymentOption == null)
        {
            PromoterPaymentOptions.Add(new PromoterPaymentOption(privateSigningPaymentMethodId, paymentMethodHandle, Id));
            return;
        }

        paymentOption.Set(privateSigningPaymentMethodId, paymentMethodHandle);
    }

    public void SetShippingAddress(string addressLine1,
                                   string addressLine2,
                                   string city,
                                   string country,
                                   string postalCode,
                                   string singleLine,
                                   string stateProvidence)
    {
        UserSettings ??= new();

        UserSettings.SetShippingAddress(addressLine1,
                                        addressLine2,
                                        city,
                                        country,
                                        postalCode,
                                        singleLine,
                                        stateProvidence);
    }

    public void SetSocialMedias(int userSociaMediaId,
                                int socialMediaTypeId,
                                string handle)
    {
        if (SocialMedias == null)
        {
            SocialMedias = new List<UserSocialMedia>
            {
                new UserSocialMedia(Id, socialMediaTypeId, handle)
            };

            return;
        }

        UserSocialMedia userSocialMedia
            = userSociaMediaId > 0
                ? SocialMedias.Single(socialMediaType => socialMediaType.Id == userSociaMediaId)
                : null;

        if (userSocialMedia == null)
        {
            SocialMedias.Add(new UserSocialMedia(Id, socialMediaTypeId, handle));

            return;
        }

        userSocialMedia.Set(handle);
    }

    public void SetStripeOptions(string customerId)
    {
        StripeCustomerId = customerId;
    }    

    public void SetStripeSubscriptionId(string subscriptionId)
    {
        StripeSubscriptionId = subscriptionId;
    }

    public void SetSubscriptionExpirationDate(DateTime? expirationDate)
    {
        SubscriptionExpirationDate = expirationDate;
    }

    public void SetSubscriptionStatus(bool isCanceled)
    {
        SubscriptionCanceled = isCanceled;
    }

    public void SetUserRole(int roleId)
    {
        if (Roles == null)
        {
            Roles = new()
            {
                new UserRole(roleId, Id)
            };

            return;
        }

        Roles.First().SetRole(roleId);
    }

    public void SetUserSettings(bool useDarkTheme,
                                string googleEmailAddress,
                                string microsoftEmailAddress,
                                string xHandle)
    {
        if (UserSettings == null)
        { 
            UserSettings = new UserSettings(Id, 
                                            useDarkTheme,
                                            googleEmailAddress,
                                            microsoftEmailAddress,
                                            xHandle);

            return;
        }

        UserSettings.Set(useDarkTheme,
                         googleEmailAddress,
                         microsoftEmailAddress,
                         xHandle);
    }
}
