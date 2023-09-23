namespace Memorabilia.Web.Services.Login.Rules;

public interface ILoginProviderRule
{
    bool Applies(LoginProvider provider);

    Task<Entity.User> GetUser(AuthenticationState state);
}
