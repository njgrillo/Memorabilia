namespace Memorabilia.MinimalAPI.Handlers.Admin.BammerTypes;

public class Get
    : RequestHandler<BammerTypeRequest>, IRequestHandler<BammerTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(BammerTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetBammerType(request.Id))));
}
