namespace Memorabilia.MinimalAPI.Handlers.Admin.TeamRoleTypes;

public class Get
    : RequestHandler<TeamRoleTypeRequest>, IRequestHandler<TeamRoleTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(TeamRoleTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetTeamRoleType(request.Id))));
}
