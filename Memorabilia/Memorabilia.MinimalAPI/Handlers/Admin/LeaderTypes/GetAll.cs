namespace Memorabilia.MinimalAPI.Handlers.Admin.LeaderTypes;

public class GetAll
    : RequestHandler<LeaderTypesRequest>, IRequestHandler<LeaderTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(LeaderTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetLeaderTypes()));

        return Results.Ok(response);
    }
}
