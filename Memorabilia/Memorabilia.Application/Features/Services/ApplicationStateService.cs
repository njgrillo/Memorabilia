namespace Memorabilia.Application.Features.Services;

public class ApplicationStateService : IApplicationStateService
{
    private readonly QueryRouter _queryRouter;

    public Entity.User CurrentUser { get; set; }

    public bool IsDarkTheme { get; set; }
        = true;

    public Constant.LoginProvider Provider { get; set; }

    public string SubscriberLevel
    {
        get
        {
            if (CurrentUser == null)
                return Constant.Role.NonSubscriber.Name;

            Entity.UserRole role = CurrentUser.Roles.FirstOrDefault();

            return Constant.Role.Find(role.RoleId)?.Name;
        }
    }

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
