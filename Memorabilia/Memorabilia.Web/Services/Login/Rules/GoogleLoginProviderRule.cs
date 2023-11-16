namespace Memorabilia.Web.Services.Login.Rules;

public class GoogleLoginProviderRule(IMediator mediator) 
    : ILoginProviderRule
{
    public bool Applies(LoginProvider provider)
        => provider.Id == LoginProvider.Google.Id;

    public async Task<Entity.User> GetUser(AuthenticationState state)
    {
        string emailAddress 
            = state.User
                   .Claims
                   .SingleOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")
                   ?.Value
                ?? string.Empty;

        if (emailAddress.IsNullOrEmpty())
            return null;

        Entity.User user 
            = await mediator.Send(new GetUser(emailAddress));

        return user;
    }
}
