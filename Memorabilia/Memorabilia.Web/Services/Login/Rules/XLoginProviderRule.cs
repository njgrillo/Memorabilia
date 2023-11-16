namespace Memorabilia.Web.Services.Login.Rules;

public class XLoginProviderRule(IMediator mediator) 
    : ILoginProviderRule
{
    public bool Applies(LoginProvider provider)
        => provider.Id == LoginProvider.X.Id;

    public async Task<Entity.User> GetUser(AuthenticationState state)
    {
        string xHandle
            = state.User
                   .Claims
                   .SingleOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")
                   ?.Value
                ?? string.Empty;

        if (xHandle.IsNullOrEmpty())
            return null;

        if (!xHandle.StartsWith('@'))
            xHandle = $"@{xHandle}";

        Entity.User user
            = await mediator.Send(new GetUserByXHandle(xHandle));

        return user;
    }
}
