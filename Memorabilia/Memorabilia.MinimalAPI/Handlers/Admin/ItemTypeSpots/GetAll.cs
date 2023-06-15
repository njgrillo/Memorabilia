namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeSpots;

public class GetAll
    : RequestHandler<ItemTypeSpotsRequest>, IRequestHandler<ItemTypeSpotsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ItemTypeSpotsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.ItemTypeSpot[]>(await QueryRouter.Send(new GetItemTypeSpots()));

        return Results.Ok(response);
    }
}
