namespace Memorabilia.MinimalAPI.Handlers.Admin.Occupations;

public class Get
    : RequestHandler<OccupationRequest>, IRequestHandler<OccupationRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(OccupationRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetOccupation(request.Id))));
}
