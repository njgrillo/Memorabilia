namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeSizes;

public class Get
    : RequestHandler<ItemTypeSizeRequest>, IRequestHandler<ItemTypeSizeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ItemTypeSizeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.ItemTypeSize>(await Mediator.Send(new GetItemTypeSize(request.Id))));
}
