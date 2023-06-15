namespace Memorabilia.MinimalAPI.Handlers.Admin.Leagues;

public class Get
    : RequestHandler<LeagueRequest>, IRequestHandler<LeagueRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(LeagueRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.League>(await QueryRouter.Send(new GetLeague(request.Id))));
}
