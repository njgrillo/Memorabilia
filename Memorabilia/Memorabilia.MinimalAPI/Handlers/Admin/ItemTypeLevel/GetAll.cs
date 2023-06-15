namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeLevel;

public class GetAll
    : RequestHandler<ItemTypeLevelsRequest>, IRequestHandler<ItemTypeLevelsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ItemTypeLevelsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.ItemTypeLevel[]>(await QueryRouter.Send(new GetItemTypeLevels()));

        return Results.Ok(response);
    }
}
