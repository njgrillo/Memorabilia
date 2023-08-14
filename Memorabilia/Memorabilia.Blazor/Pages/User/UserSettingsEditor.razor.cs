namespace Memorabilia.Blazor.Pages.User;

public partial class UserSettingsEditor
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected UserSettingsEditModel EditModel
        = new();

    protected override void OnInitialized()
    {
        EditModel = new UserSettingsEditModel(ApplicationStateService.CurrentUser);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveUserSettings.Command(EditModel));

        ApplicationStateService.IsDarkTheme = EditModel.UseDarkTheme;

        Snackbar.Add("User Settings were saved successfully!", Severity.Success);

        await Mediator.Publish(new ThemeChangedNotification());
    }
}
