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
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected UserSettingsEditModel EditModel
        = new();

    protected override async Task OnInitializedAsync()
    {
        await Load();
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveUserSettings.Command(EditModel));

        ApplicationStateService.IsDarkTheme = EditModel.UseDarkTheme;

        Snackbar.Add("User Settings were saved successfully!", Severity.Success);

        await Mediator.Publish(new ThemeChangedNotification());

        await Load();
    }

    private async Task Load()
    {
        Entity.User user
            = await QueryRouter.Send(new GetUserById(ApplicationStateService.CurrentUser.Id));

        EditModel = new UserSettingsEditModel(user);
    }
}
