namespace Memorabilia.Application.Features.Services;

public class ApplicationStateService : IApplicationStateService
{
    private readonly QueryRouter _queryRouter;

    public Entity.User CurrentUser { get; set; }

    public bool IsDarkTheme { get; set; }

    public ApplicationStateService(QueryRouter queryRouter)
    {
        _queryRouter = queryRouter;
    }

    public async Task Load(int userId)
    {
        CurrentUser = await _queryRouter.Send(new GetUserById(userId));

        IsDarkTheme = CurrentUser.UserSettings?.UseDarkTheme ?? false;
    }

    public void Logout()
    {
        CurrentUser = null;
        IsDarkTheme = false;
    }

    public void Set(Entity.User user)
    {
        CurrentUser = user;

        IsDarkTheme = CurrentUser.UserSettings?.UseDarkTheme ?? false;
    }
}
