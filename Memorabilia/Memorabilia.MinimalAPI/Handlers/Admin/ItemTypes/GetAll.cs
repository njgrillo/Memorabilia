namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypes;

public class GetAll
    : RequestHandler<ItemTypesRequest>, IRequestHandler<ItemTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ItemTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetItemTypes()));

        return Results.Ok(response);
    }
}
