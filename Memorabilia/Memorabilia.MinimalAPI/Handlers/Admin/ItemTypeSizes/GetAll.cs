namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeSizes;

public class GetAll
    : RequestHandler<ItemTypeSizesRequest>, IRequestHandler<ItemTypeSizesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ItemTypeSizesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.ItemTypeSize[]>(await Mediator.Send(new GetItemTypeSizes()));

        return Results.Ok(response);
    }
}
