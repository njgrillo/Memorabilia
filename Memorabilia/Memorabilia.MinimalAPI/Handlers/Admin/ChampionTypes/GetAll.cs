namespace Memorabilia.MinimalAPI.Handlers.Admin.ChampionTypes;

public class GetAll
    : RequestHandler<ChampionTypesRequest>, IRequestHandler<ChampionTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(ChampionTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetChampionTypes()));

        return Results.Ok(response);
    }
}
