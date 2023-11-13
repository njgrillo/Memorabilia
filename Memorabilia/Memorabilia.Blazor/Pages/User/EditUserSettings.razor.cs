namespace Memorabilia.Blazor.Pages.User;

public partial class EditUserSettings
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public StripeService StripeService { get; set; }

    [Inject]
    public IStripeSettings StripeSettings { get; set; }

    protected UserSettingsEditModel EditModel
        = new();

    private bool _showCancelMembership;

    private bool _showUpgradeMembership;

    protected override async Task OnInitializedAsync()
    {
       _showCancelMembership
            = !ApplicationStateService.CurrentUser.SubscriptionExpirationDate.HasValue
              && ApplicationStateService.CurrentUser.IsActiveMember();

        _showUpgradeMembership
            = (!ApplicationStateService.CurrentUser.SubscriptionCanceled || (ApplicationStateService.CurrentUser.SubscriptionExpirationDate.HasValue && ApplicationStateService.CurrentUser.SubscriptionExpirationDate.Value < DateTime.UtcNow))
              && ApplicationStateService.CurrentUser.IsUpgradeEligible();

        await Load();
    }

    protected async Task OnSave()
    {
        await Mediator.Send(new SaveUserSettings.Command(EditModel));

        ApplicationStateService.IsDarkTheme = EditModel.UseDarkTheme;

        Snackbar.Add("User Settings were saved successfully!", Severity.Success);

        await Mediator.Publish(new ThemeChangedNotification());

        await Load();
    }

    private async Task CancelMembership()
    {
        DateTime? expirationDate
            = await StripeService.CancelSubscriptionAsync(ApplicationStateService.CurrentUser.StripeSubscriptionId);

        var userEditModel 
            = new UserEditModel(ApplicationStateService.CurrentUser);

        userEditModel.CancelSubscription(expirationDate);

        await Mediator.Send(new SaveUser(userEditModel));       

        Snackbar.Add($"Membership has been canceled successfully!  You will have until {expirationDate.Value:MM-dd-yyyy} to continue using membership features.", Severity.Success);
                
        _showCancelMembership = false;
        _showUpgradeMembership = false;
    }

    private async Task Load()
    {
        Entity.User user
            = await Mediator.Send(new GetUserById(ApplicationStateService.CurrentUser.Id));

        EditModel = new UserSettingsEditModel(user);
    }

    private void UpgradeMembership()
    {
        NavigationManager.NavigateTo(NavigationPath.SubscriptionUpgrade);
    }
}
