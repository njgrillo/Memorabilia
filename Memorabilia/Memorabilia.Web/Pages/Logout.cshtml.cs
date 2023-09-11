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
        try
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            _applicationStateService.Logout();
        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }

        return LocalRedirect("/");
    }
}
