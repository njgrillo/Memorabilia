namespace Memorabilia.MinimalAPI.Handlers.Admin.ProjectStatusTypes;

public class GetAll
    : RequestHandler<ProjectStatusTypesRequest>, IRequestHandler<ProjectStatusTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ProjectStatusTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetProjectStatusTypes()));

        return Results.Ok(response);
    }
}
