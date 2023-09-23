namespace Memorabilia.Web.Pages;

public class MicrosoftLoginModel : PageModel
{
    public IActionResult OnGetAsync(string returnUrl = null)
    {
        string provider = "Microsoft";

        var authenticationProperties = new AuthenticationProperties
        {
            RedirectUri = Url.Page("./MicrosoftLogin",
                                   pageHandler: "Callback",
                                   values: new { returnUrl })
        };

        return new ChallengeResult(provider, authenticationProperties);
    }

    public async Task<IActionResult> OnGetCallbackAsync()
    {
        ClaimsIdentity microsoftUser = User.Identities.FirstOrDefault();

        if (microsoftUser.IsAuthenticated)
        {
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = Request.Host.Value
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                          new ClaimsPrincipal(microsoftUser),
                                          authProperties);
        }

        return LocalRedirect("/");
    }
}
