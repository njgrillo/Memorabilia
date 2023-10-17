namespace Memorabilia.MinimalAPI.Handlers.Admin.SportLeagueLevels;

public class GetAll
    : RequestHandler<SportLeagueLevelsRequest>, IRequestHandler<SportLeagueLevelsRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(SportLeagueLevelsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.SportLeagueLevel[]>(await Mediator.Send(new GetSportLeagueLevels()));

        return Results.Ok(response);
    }
}
