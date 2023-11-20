namespace Memorabilia.Web.Pages;

public class LogoutModel(IApplicationStateService applicationStateService) 
    : PageModel
{
    public async Task<IActionResult> OnGetAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        applicationStateService.Logout();

        return LocalRedirect("/");
    }
}
