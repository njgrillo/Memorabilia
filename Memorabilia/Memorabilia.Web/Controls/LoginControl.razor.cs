namespace Memorabilia.Web.Controls;

public partial class LoginControl
{
    [Inject]
    public IHttpContextAccessor HttpContextAccessor { get; set; }

    protected string Avatar;

    protected string GivenName;

    protected string Surname;    

    private ClaimsPrincipal _user;

    protected override void OnInitialized()
    {
        _user = HttpContextAccessor.HttpContext.User;

        Claim givenName = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.GivenName);

        GivenName = givenName != null
                ? givenName.Value
                : _user.Identity.Name;

        Claim surname = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Surname);

        Surname = surname != null
                ? surname.Value
                : string.Empty;

        Claim avatar = HttpContextAccessor.HttpContext.User.FindFirst("urn:google:image");

        Avatar = avatar != null
                ? avatar.Value
                : string.Empty;
    }
}
