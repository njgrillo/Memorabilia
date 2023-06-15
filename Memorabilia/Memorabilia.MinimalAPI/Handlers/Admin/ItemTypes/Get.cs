namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypes;

public class Get
    : RequestHandler<ItemTypeRequest>, IRequestHandler<ItemTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ItemTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetItemType(request.Id))));
}
