namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeLevel;

public class Get
    : RequestHandler<ItemTypeLevelRequest>, IRequestHandler<ItemTypeLevelRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ItemTypeLevelRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.ItemTypeLevel>(await Mediator.Send(new GetItemTypeLevel(request.Id))));
}
