namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeLevel;

public class GetAll
    : RequestHandler<ItemTypeLevelsRequest>, IRequestHandler<ItemTypeLevelsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ItemTypeLevelsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.ItemTypeLevel[]>(await Mediator.Send(new GetItemTypeLevels()));

        return Results.Ok(response);
    }
}
