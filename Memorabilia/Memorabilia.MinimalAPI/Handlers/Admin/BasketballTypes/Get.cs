namespace Memorabilia.MinimalAPI.Handlers.Admin.BasketballTypes;

public class Get
    : RequestHandler<BasketballTypeRequest>, IRequestHandler<BasketballTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(BasketballTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetBasketballType(request.Id))));
}
