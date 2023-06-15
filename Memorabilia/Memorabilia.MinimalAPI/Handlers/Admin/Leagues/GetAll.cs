namespace Memorabilia.MinimalAPI.Handlers.Admin.Leagues;

public class GetAll
    : RequestHandler<LeaguesRequest>, IRequestHandler<LeaguesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(LeaguesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.League[]>(await QueryRouter.Send(new GetLeagues()));

        return Results.Ok(response);
    }
}
