namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeSpots;

public class Get
    : RequestHandler<ItemTypeSpotRequest>, IRequestHandler<ItemTypeSpotRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ItemTypeSpotRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.ItemTypeSpot>(await Mediator.Send(new GetItemTypeSpot(request.Id))));
}
