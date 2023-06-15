namespace Memorabilia.MinimalAPI.Handlers.Admin.Spots;

public class GetAll
    : RequestHandler<SpotsRequest>, IRequestHandler<SpotsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(SpotsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetSpots()));

        return Results.Ok(response);
    }
}
