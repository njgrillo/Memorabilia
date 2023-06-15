namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeLevel;

public class Get
    : RequestHandler<ItemTypeLevelRequest>, IRequestHandler<ItemTypeLevelRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ItemTypeLevelRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.ItemTypeLevel>(await QueryRouter.Send(new GetItemTypeLevel(request.Id))));
}
