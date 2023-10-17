namespace Memorabilia.MinimalAPI.Handlers.Admin.ProjectTypes;

public class Get
    : RequestHandler<ProjectTypeRequest>, IRequestHandler<ProjectTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ProjectTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetProjectType(request.Id))));
}
