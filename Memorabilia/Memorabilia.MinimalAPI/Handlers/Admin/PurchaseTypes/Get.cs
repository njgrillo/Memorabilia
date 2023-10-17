namespace Memorabilia.MinimalAPI.Handlers.Admin.PurchaseTypes;

public class Get
    : RequestHandler<PurchaseTypeRequest>, IRequestHandler<PurchaseTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(PurchaseTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetPurchaseType(request.Id))));
}
