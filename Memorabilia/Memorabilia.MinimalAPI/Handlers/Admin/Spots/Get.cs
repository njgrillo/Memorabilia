namespace Memorabilia.MinimalAPI.Handlers.Admin.Spots;

public class Get
    : RequestHandler<SpotRequest>, IRequestHandler<SpotRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(SpotRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetSpot(request.Id))));
}
