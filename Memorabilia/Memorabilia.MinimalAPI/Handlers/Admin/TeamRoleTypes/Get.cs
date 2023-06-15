namespace Memorabilia.MinimalAPI.Handlers.Admin.TeamRoleTypes;

public class Get
    : RequestHandler<TeamRoleTypeRequest>, IRequestHandler<TeamRoleTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(TeamRoleTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetTeamRoleType(request.Id))));
}
