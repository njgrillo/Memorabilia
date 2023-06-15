namespace Memorabilia.MinimalAPI.Handlers.Admin.Orientations;

public class Get
    : RequestHandler<OrientationRequest>, IRequestHandler<OrientationRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(OrientationRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetOrientation(request.Id))));
}
