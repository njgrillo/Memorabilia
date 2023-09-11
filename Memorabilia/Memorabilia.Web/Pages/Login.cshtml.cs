namespace Memorabilia.Web.Pages;

public class LoginModel : PageModel
{   
    public IActionResult OnGetAsync(string returnUrl = null)
    {
        string provider = "Google";

        var authenticationProperties = new AuthenticationProperties
        {
            RedirectUri = Url.Page("./Login",
                                   pageHandler: "Callback",
                                   values: new { returnUrl })
        };

        return new ChallengeResult(provider, authenticationProperties);
    }

    public async Task<IActionResult> OnGetCallbackAsync()
    {
        ClaimsIdentity googleUser = User.Identities.FirstOrDefault();

        if (googleUser.IsAuthenticated)
        {
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = this.Request.Host.Value
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                          new ClaimsPrincipal(googleUser),
                                          authProperties);
        }

        return LocalRedirect("/");
    }
}
