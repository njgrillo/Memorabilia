namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeSports;

public class Get
    : RequestHandler<ItemTypeSportRequest>, IRequestHandler<ItemTypeSportRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ItemTypeSportRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.ItemTypeSport>(await QueryRouter.Send(new GetItemTypeSport(request.Id))));
}
