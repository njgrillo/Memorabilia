namespace Memorabilia.MinimalAPI.Handlers.Admin.ProjectStatusTypes;

public class Get
    : RequestHandler<ProjectStatusTypeRequest>, IRequestHandler<ProjectStatusTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ProjectStatusTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetProjectStatusType(request.Id))));
}
