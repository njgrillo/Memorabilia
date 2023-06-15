namespace Memorabilia.MinimalAPI.Handlers.Admin.BasketballTypes;

public class GetAll
    : RequestHandler<BasketballTypesRequest>, IRequestHandler<BasketballTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(BasketballTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetBasketballTypes()));

        return Results.Ok(response);
    }
}
