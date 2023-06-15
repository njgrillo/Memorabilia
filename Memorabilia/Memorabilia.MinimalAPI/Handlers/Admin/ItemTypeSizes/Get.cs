namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeSizes;

public class Get
    : RequestHandler<ItemTypeSizeRequest>, IRequestHandler<ItemTypeSizeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ItemTypeSizeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.ItemTypeSize>(await QueryRouter.Send(new GetItemTypeSize(request.Id))));
}
