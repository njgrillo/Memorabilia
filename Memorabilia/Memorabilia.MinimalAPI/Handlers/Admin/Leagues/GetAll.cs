namespace Memorabilia.MinimalAPI.Handlers.Admin.Leagues;

public class GetAll
    : RequestHandler<LeaguesRequest>, IRequestHandler<LeaguesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(LeaguesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.League[]>(await Mediator.Send(new GetLeagues()));

        return Results.Ok(response);
    }
}
