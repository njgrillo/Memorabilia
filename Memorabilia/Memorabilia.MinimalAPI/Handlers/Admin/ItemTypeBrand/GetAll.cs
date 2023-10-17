namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeBrand;

public class GetAll
    : RequestHandler<ItemTypeBrandsRequest>, IRequestHandler<ItemTypeBrandsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ItemTypeBrandsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.ItemTypeBrand[]>(await Mediator.Send(new GetItemTypeBrands()));

        return Results.Ok(response);
    }
}
