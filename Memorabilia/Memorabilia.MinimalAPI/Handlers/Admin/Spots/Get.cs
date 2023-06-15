namespace Memorabilia.MinimalAPI.Handlers.Admin.Spots;

public class Get
    : RequestHandler<SpotRequest>, IRequestHandler<SpotRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(SpotRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetSpot(request.Id))));
}
