namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeBrand;

public class GetAll
    : RequestHandler<ItemTypeBrandsRequest>, IRequestHandler<ItemTypeBrandsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ItemTypeBrandsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.ItemTypeBrand[]>(await QueryRouter.Send(new GetItemTypeBrands()));

        return Results.Ok(response);
    }
}
