namespace Memorabilia.Web.Services.Login;

public class LoginProviderService
{
    private readonly ILoginProviderRuleFactory _loginProviderRuleFactory;

    public LoginProviderService(ILoginProviderRuleFactory loginProviderRuleFactory)
    {
        _loginProviderRuleFactory = loginProviderRuleFactory;
    }

    public async Task<Entity.User> GetUser(AuthenticationState state, LoginProvider provider)
    {
        foreach (ILoginProviderRule rule in _loginProviderRuleFactory.Rules)
        {
            if (!rule.Applies(provider))
                continue;

            return await rule.GetUser(state);
        }

        return null;
    }
}
