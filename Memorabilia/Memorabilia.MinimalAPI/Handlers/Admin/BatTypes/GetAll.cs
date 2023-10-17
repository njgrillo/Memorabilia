namespace Memorabilia.MinimalAPI.Handlers.Admin.BatTypes;

public class GetAll
    : RequestHandler<BatTypesRequest>, IRequestHandler<BatTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(BatTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetBatTypes()));

        return Results.Ok(response);
    }
}
