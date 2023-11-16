namespace Memorabilia.Blazor.Controls.Login;

public partial class LoginRegisterControl
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected async Task Login()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<LoginSelectorDialog>("Select Login Provider", [], options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var provider = (LoginProvider)result.Data;

        string url = $"/{provider.Name}login";

        NavigationManager.NavigateTo(url, true);
    }

    protected void Register()
    {
        NavigationManager.NavigateTo("Register");
    }
}
