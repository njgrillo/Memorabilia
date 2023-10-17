namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypes;

public class Get
    : RequestHandler<ItemTypeRequest>, IRequestHandler<ItemTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ItemTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetItemType(request.Id))));
}
