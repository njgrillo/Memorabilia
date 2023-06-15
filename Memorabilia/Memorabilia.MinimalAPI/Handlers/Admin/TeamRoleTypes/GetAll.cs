namespace Memorabilia.MinimalAPI.Handlers.Admin.TeamRoleTypes;

public class GetAll
    : RequestHandler<TeamRoleTypesRequest>, IRequestHandler<TeamRoleTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(TeamRoleTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetTeamRoleTypes()));

        return Results.Ok(response);
    }
}
