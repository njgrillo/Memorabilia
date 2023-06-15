namespace Memorabilia.MinimalAPI.Handlers.Admin.BatTypes;

public class Get
    : RequestHandler<BatTypeRequest>, IRequestHandler<BatTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(BatTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetBatType(request.Id))));
}
