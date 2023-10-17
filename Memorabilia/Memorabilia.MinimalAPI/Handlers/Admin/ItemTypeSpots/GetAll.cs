namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeSpots;

public class GetAll
    : RequestHandler<ItemTypeSpotsRequest>, IRequestHandler<ItemTypeSpotsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ItemTypeSpotsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.ItemTypeSpot[]>(await Mediator.Send(new GetItemTypeSpots()));

        return Results.Ok(response);
    }
}
