namespace Memorabilia.MinimalAPI.Handlers.Admin.Leagues;

public class Get
    : RequestHandler<LeagueRequest>, IRequestHandler<LeagueRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(LeagueRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.League>(await Mediator.Send(new GetLeague(request.Id))));
}
