namespace Memorabilia.MinimalAPI.Handlers.Admin.Teams;

public class Get
    : RequestHandler<TeamRequest>, IRequestHandler<TeamRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(TeamRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Team>(await Mediator.Send(new GetTeam(request.Id))));
}
