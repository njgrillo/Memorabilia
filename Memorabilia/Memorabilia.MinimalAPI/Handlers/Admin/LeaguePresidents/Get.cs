namespace Memorabilia.MinimalAPI.Handlers.Admin.LeaguePresidents;

public class Get
    : RequestHandler<LeaguePresidentRequest>, IRequestHandler<LeaguePresidentRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(LeaguePresidentRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<LeaguePresidentApiModel>(
            (await QueryRouter.Send(new GetLeaguePresident(request.Id))).ToModel()));
}
