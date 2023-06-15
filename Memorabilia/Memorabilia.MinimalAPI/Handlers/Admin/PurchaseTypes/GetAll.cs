namespace Memorabilia.MinimalAPI.Handlers.Admin.PurchaseTypes;

public class GetAll
    : RequestHandler<PurchaseTypesRequest>, IRequestHandler<PurchaseTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(PurchaseTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetPurchaseTypes()));

        return Results.Ok(response);
    }
}
