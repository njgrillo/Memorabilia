namespace Memorabilia.MinimalAPI.Handlers.Admin.LeaguePresidents;

public class Get
    : RequestHandler<LeaguePresidentRequest>, IRequestHandler<LeaguePresidentRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(LeaguePresidentRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<LeaguePresidentApiModel>(
            (await Mediator.Send(new GetLeaguePresident(request.Id))).ToModel()));
}
