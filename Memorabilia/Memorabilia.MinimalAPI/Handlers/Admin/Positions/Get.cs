namespace Memorabilia.MinimalAPI.Handlers.Admin.Positions;

public class Get
    : RequestHandler<PositionRequest>, IRequestHandler<PositionRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(PositionRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Position>(await QueryRouter.Send(new GetPosition(request.Id))));
}
