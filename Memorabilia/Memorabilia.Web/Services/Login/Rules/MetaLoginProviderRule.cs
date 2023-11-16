namespace Memorabilia.Web.Services.Login.Rules;

public class MetaLoginProviderRule
    : ILoginProviderRule
{
    public bool Applies(LoginProvider provider)
        => provider.Id == LoginProvider.Meta.Id;

    public async Task<Entity.User> GetUser(AuthenticationState state)
    {
        string metaHandle
            = state.User
                   .Claims
                   .SingleOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")
                   ?.Value
                ?? string.Empty;

        await Task.CompletedTask;

        if (metaHandle.IsNullOrEmpty())
            return null;

        return null;

        //TODO - Get user by x handle
        //Entity.User user
        //    = await _mediator.Send(new GetUserByXHandle(emailAddress));

        //return user;
    }
}
