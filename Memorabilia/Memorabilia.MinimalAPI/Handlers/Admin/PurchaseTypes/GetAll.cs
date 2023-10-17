namespace Memorabilia.MinimalAPI.Handlers.Admin.PurchaseTypes;

public class GetAll
    : RequestHandler<PurchaseTypesRequest>, IRequestHandler<PurchaseTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(PurchaseTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetPurchaseTypes()));

        return Results.Ok(response);
    }
}
