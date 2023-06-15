namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeGameStyle;

public class Get
    : RequestHandler<ItemTypeGameStyleRequest>, IRequestHandler<ItemTypeGameStyleRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ItemTypeGameStyleRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.ItemTypeGameStyleType>(await QueryRouter.Send(new GetItemTypeGameStyle(request.Id))));
}
