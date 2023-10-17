namespace Memorabilia.MinimalAPI.Handlers.Admin.BasketballTypes;

public class GetAll
    : RequestHandler<BasketballTypesRequest>, IRequestHandler<BasketballTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(BasketballTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetBasketballTypes()));

        return Results.Ok(response);
    }
}
