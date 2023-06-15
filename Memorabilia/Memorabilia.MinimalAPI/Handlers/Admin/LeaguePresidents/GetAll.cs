namespace Memorabilia.MinimalAPI.Handlers.Admin.LeaguePresidents;

public class GetAll
    : RequestHandler<LeaguePresidentsRequest>, IRequestHandler<LeaguePresidentsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(LeaguePresidentsRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<LeaguePresidentAPIModel[]>(
                (await QueryRouter.Send(new GetLeaguePresidents())).ToModelArray()));
}
