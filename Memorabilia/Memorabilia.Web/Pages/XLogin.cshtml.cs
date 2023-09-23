namespace Memorabilia.Web.Pages;

public class XLoginModel : PageModel
{
    public IActionResult OnGetAsync(string returnUrl = null)
    {
        string provider = "Twitter";

        var authenticationProperties = new AuthenticationProperties
        {
            RedirectUri = Url.Page("./XLogin",
                                   pageHandler: "Callback",
                                   values: new { returnUrl })
        };

        return new ChallengeResult(provider, authenticationProperties);
    }

    public async Task<IActionResult> OnGetCallbackAsync()
    {
        ClaimsIdentity xUser = User.Identities.FirstOrDefault();        

        if (xUser.IsAuthenticated)
        {
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = Request.Host.Value
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                          new ClaimsPrincipal(xUser),
                                          authProperties);
        }

        return LocalRedirect("/");
    }
}
