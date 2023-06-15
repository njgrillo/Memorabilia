namespace Memorabilia.MinimalAPI.Handlers.Admin.ProjectTypes;

public class Get
    : RequestHandler<ProjectTypeRequest>, IRequestHandler<ProjectTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ProjectTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetProjectType(request.Id))));
}
