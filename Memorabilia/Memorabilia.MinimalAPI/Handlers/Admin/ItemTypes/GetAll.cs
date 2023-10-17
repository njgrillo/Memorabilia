namespace Memorabilia.MinimalAPI.Handlers.Admin.ItemTypes;

public class GetAll
    : RequestHandler<ItemTypesRequest>, IRequestHandler<ItemTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ItemTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetItemTypes()));

        return Results.Ok(response);
    }
}
