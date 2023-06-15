namespace Memorabilia.MinimalAPI.Handlers.Admin.SportLeagueLevels;

public class Get
    : RequestHandler<SportLeagueLevelRequest>, IRequestHandler<SportLeagueLevelRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(SportLeagueLevelRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.SportLeagueLevel>(await QueryRouter.Send(new GetSportLeagueLevel(request.Id))));
}
