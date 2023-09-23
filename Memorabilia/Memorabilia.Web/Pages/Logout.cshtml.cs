namespace Memorabilia.Web.Pages;

public class LogoutModel : PageModel
{
    private readonly IApplicationStateService _applicationStateService;

    public LogoutModel(IApplicationStateService applicationStateService)
    {
        _applicationStateService = applicationStateService;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        _applicationStateService.Logout();

        return LocalRedirect("/");
    }
}
