namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeGameStyle;

public class Get
    : RequestHandler<ItemTypeGameStyleRequest>, IRequestHandler<ItemTypeGameStyleRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ItemTypeGameStyleRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.ItemTypeGameStyleType>(await Mediator.Send(new GetItemTypeGameStyle(request.Id))));
}
