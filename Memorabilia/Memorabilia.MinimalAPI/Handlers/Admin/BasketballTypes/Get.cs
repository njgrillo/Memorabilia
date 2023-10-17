namespace Memorabilia.MinimalAPI.Handlers.Admin.BasketballTypes;

public class Get
    : RequestHandler<BasketballTypeRequest>, IRequestHandler<BasketballTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(BasketballTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetBasketballType(request.Id))));
}
