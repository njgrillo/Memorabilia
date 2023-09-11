namespace Memorabilia.Web.Controls;

public partial class LoginControl
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IHttpContextAccessor HttpContextAccessor { get; set; }

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
}
