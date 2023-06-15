namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeGameStyle;

public class GetAll
    : RequestHandler<ItemTypeGameStylesRequest>, IRequestHandler<ItemTypeGameStylesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ItemTypeGameStylesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.ItemTypeGameStyleType[]>(await QueryRouter.Send(new GetItemTypeGameStyles()));

        return Results.Ok(response);
    }
}
