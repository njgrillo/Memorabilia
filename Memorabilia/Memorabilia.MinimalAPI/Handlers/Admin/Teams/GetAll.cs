namespace Memorabilia.MinimalAPI.Handlers.Admin.Teams;

public class GetAll
    : RequestHandler<TeamsRequest>, IRequestHandler<TeamsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(TeamsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.Team[]>(await Mediator.Send(new GetTeams()));

        return Results.Ok(response);
    }
}
