using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class RegisterLoginMembershipDialog
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    private bool _loggedIn;

    protected override void OnInitialized()
    {
        _loggedIn = ApplicationStateService.CurrentUser != null;
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    protected void Register()
    {
        NavigationManager.NavigateTo("Register");
    }
}
