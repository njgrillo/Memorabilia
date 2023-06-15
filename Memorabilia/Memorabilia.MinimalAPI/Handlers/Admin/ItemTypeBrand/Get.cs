namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeBrand;

public class Get
    : RequestHandler<ItemTypeBrandRequest>, IRequestHandler<ItemTypeBrandRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ItemTypeBrandRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.ItemTypeBrand>(await QueryRouter.Send(new GetItemTypeBrand(request.Id))));
}
