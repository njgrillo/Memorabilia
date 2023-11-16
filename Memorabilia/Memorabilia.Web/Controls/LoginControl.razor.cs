using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Web.Controls;

public partial class LoginControl
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IHttpContextAccessor HttpContextAccessor { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected string Avatar;

    protected string Username;

    private ClaimsPrincipal _user;

    protected override void OnInitialized()
    {
        _user = HttpContextAccessor.HttpContext.User;

        Claim avatar = HttpContextAccessor.HttpContext.User.FindFirst("urn:google:image");

        Avatar = avatar != null
                ? avatar.Value
                : string.Empty;

        Username = ApplicationStateService.CurrentUser?.Username ?? string.Empty;
    }

    protected async Task OnLoginClick()
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
}
