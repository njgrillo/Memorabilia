namespace Memorabilia.MinimalAPI.Handlers.Admin.LeaguePresidents;

public class GetAll
    : RequestHandler<LeaguePresidentsRequest>, IRequestHandler<LeaguePresidentsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(LeaguePresidentsRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<LeaguePresidentApiModel[]>(
                (await Mediator.Send(new GetLeaguePresidents())).ToModelArray()));
}
