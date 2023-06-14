namespace Memorabilia.Application.Features.Services;

public class ApplicationStateService : IApplicationStateService
{
    private readonly QueryRouter _queryRouter;

    public Entity.User CurrentUser { get; set; }

    public ApplicationStateService(QueryRouter queryRouter)
    {
        _queryRouter = queryRouter;
    }

    public async Task Load(int userId)
    {
        CurrentUser = await _queryRouter.Send(new GetUserById(userId));
    }

    public void Set(Entity.User user)
    {
        CurrentUser = user;
    }
}
