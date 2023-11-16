namespace Memorabilia.Web.Services.Login;

public class LoginProviderService(ILoginProviderRuleFactory loginProviderRuleFactory)
{
    public async Task<Entity.User> GetUser(AuthenticationState state, LoginProvider provider)
    {
        foreach (ILoginProviderRule rule in loginProviderRuleFactory.Rules)
        {
            if (!rule.Applies(provider))
                continue;

            return await rule.GetUser(state);
        }

        return null;
    }
}
