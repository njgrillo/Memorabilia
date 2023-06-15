namespace Memorabilia.MinimalAPI.Handlers.Admin.ProjectTypes;

public class GetAll
    : RequestHandler<ProjectTypesRequest>, IRequestHandler<ProjectTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ProjectTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetProjectTypes()));

        return Results.Ok(response);
    }
}
