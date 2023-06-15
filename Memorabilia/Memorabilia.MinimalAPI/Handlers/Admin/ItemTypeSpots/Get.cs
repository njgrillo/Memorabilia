namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeSpots;

public class Get
    : RequestHandler<ItemTypeSpotRequest>, IRequestHandler<ItemTypeSpotRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ItemTypeSpotRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.ItemTypeSpot>(await QueryRouter.Send(new GetItemTypeSpot(request.Id))));
}
