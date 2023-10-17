namespace Memorabilia.MinimalAPI.Handlers.Admin.ProjectStatusTypes;

public class GetAll
    : RequestHandler<ProjectStatusTypesRequest>, IRequestHandler<ProjectStatusTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(ProjectStatusTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetProjectStatusTypes()));

        return Results.Ok(response);
    }
}
