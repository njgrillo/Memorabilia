namespace Memorabilia.MinimalAPI.Handlers.Admin.Orientations;

public class Get
    : RequestHandler<OrientationRequest>, IRequestHandler<OrientationRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(OrientationRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetOrientation(request.Id))));
}
