namespace Memorabilia.MinimalAPI.Handlers.Admin.ProjectStatusTypes;

public class Get
    : RequestHandler<ProjectStatusTypeRequest>, IRequestHandler<ProjectStatusTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ProjectStatusTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetProjectStatusType(request.Id))));
}
