﻿namespace Memorabilia.Web.Services.Login.Rules;

public class MicrosoftLoginProviderRule : ILoginProviderRule
{
    private readonly IMediator _mediator;

    public MicrosoftLoginProviderRule(IMediator mediator)
    {
        _mediator = mediator;
    }

    public bool Applies(LoginProvider provider)
        => provider.Id == LoginProvider.Microsoft.Id;

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
            = await _mediator.Send(new GetUserByMicrosoftEmailAddress(emailAddress));

        return user;
    }
}
