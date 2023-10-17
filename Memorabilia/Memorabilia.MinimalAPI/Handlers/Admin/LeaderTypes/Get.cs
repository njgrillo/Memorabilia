namespace Memorabilia.MinimalAPI.Handlers.Admin.LeaderTypes;

public class Get
    : RequestHandler<LeaderTypeRequest>, IRequestHandler<LeaderTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(LeaderTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetLeaderType(request.Id))));
}
