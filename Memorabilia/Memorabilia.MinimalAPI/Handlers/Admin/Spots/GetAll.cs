namespace Memorabilia.MinimalAPI.Handlers.Admin.Spots;

public class GetAll
    : RequestHandler<SpotsRequest>, IRequestHandler<SpotsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(SpotsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetSpots()));

        return Results.Ok(response);
    }
}
