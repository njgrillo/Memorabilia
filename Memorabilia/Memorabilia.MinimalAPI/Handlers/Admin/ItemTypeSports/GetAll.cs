namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypeSports;

public class GetAll
    : RequestHandler<ItemTypeSportsRequest>, IRequestHandler<ItemTypeSportsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ItemTypeSportsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.ItemTypeSport[]>(await Mediator.Send(new GetItemTypeSports()));

        return Results.Ok(response);
    }
}
