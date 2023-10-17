namespace Memorabilia.MinimalAPI.Handlers.Admin.Positions;

public class Get
    : RequestHandler<PositionRequest>, IRequestHandler<PositionRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(PositionRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Position>(await Mediator.Send(new GetPosition(request.Id))));
}
