namespace Memorabilia.MinimalAPI.Handlers.Admin.PurchaseTypes;

public class Get
    : RequestHandler<PurchaseTypeRequest>, IRequestHandler<PurchaseTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(PurchaseTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetPurchaseType(request.Id))));
}
