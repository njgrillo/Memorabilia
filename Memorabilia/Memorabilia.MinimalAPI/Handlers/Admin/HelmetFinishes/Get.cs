namespace Memorabilia.MinimalAPI.Handlers.Admin.HelmetFinishes;

public class Get
    : RequestHandler<HelmetFinishRequest>, IRequestHandler<HelmetFinishRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(HelmetFinishRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetHelmetFinish(request.Id))));
}
