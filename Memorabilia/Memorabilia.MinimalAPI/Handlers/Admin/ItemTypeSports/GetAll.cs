namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeSports;

public class GetAll
    : RequestHandler<ItemTypeSportsRequest>, IRequestHandler<ItemTypeSportsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ItemTypeSportsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.ItemTypeSport[]>(await QueryRouter.Send(new GetItemTypeSports()));

        return Results.Ok(response);
    }
}
