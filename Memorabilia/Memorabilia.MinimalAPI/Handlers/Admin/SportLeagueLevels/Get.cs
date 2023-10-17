namespace Memorabilia.MinimalAPI.Handlers.Admin.SportLeagueLevels;

public class Get
    : RequestHandler<SportLeagueLevelRequest>, IRequestHandler<SportLeagueLevelRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(SportLeagueLevelRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.SportLeagueLevel>(await Mediator.Send(new GetSportLeagueLevel(request.Id))));
}
