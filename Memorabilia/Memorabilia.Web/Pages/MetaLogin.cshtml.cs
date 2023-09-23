namespace Memorabilia.Web.Pages;

public class MetaLoginModel : PageModel
{
    public IActionResult OnGetAsync(string returnUrl = null)
    {
        string provider = "Facebook";

        var authenticationProperties = new AuthenticationProperties
        {
            RedirectUri = Url.Page("./MetaLogin",
                                   pageHandler: "Callback",
                                   values: new { returnUrl })
        };

        return new ChallengeResult(provider, authenticationProperties);
    }

    public async Task<IActionResult> OnGetCallbackAsync()
    {
        ClaimsIdentity facebookUser = User.Identities.FirstOrDefault();

        if (facebookUser.IsAuthenticated)
        {
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = Request.Host.Value
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                          new ClaimsPrincipal(facebookUser),
                                          authProperties);
        }

        return LocalRedirect("/");
    }
}
