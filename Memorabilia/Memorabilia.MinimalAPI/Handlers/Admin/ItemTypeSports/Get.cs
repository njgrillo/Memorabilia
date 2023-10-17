namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeSports;

public class Get
    : RequestHandler<ItemTypeSportRequest>, IRequestHandler<ItemTypeSportRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ItemTypeSportRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.ItemTypeSport>(await Mediator.Send(new GetItemTypeSport(request.Id))));
}
