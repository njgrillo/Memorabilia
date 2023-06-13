namespace Memorabilia.Blazor.Services;

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
}
