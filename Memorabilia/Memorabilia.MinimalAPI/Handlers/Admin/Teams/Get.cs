namespace Memorabilia.MinimalAPI.Handlers.Admin.Teams;

public class Get
    : RequestHandler<TeamRequest>, IRequestHandler<TeamRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(TeamRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Team>(await QueryRouter.Send(new GetTeam(request.Id))));
}
