namespace Memorabilia.MinimalAPI.Handlers.Admin.Positions;

public class GetAll
    : RequestHandler<PositionsRequest>, IRequestHandler<PositionsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(PositionsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.Position[]>(await QueryRouter.Send(new GetPositions()));

        return Results.Ok(response);
    }
}
