namespace Memorabilia.MinimalAPI.Handlers.Admin.GameStyleTypes;

public class Get
    : RequestHandler<GameStyleTypeRequest>, IRequestHandler<GameStyleTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(GameStyleTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetGameStyleType(request.Id))));
}
