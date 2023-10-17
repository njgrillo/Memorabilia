namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeBrand;

public class Get
    : RequestHandler<ItemTypeBrandRequest>, IRequestHandler<ItemTypeBrandRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ItemTypeBrandRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.ItemTypeBrand>(await Mediator.Send(new GetItemTypeBrand(request.Id))));
}
