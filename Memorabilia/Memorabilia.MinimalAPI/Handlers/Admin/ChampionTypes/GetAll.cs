namespace Memorabilia.MinimalAPI.Handlers.Admin.ChampionTypes;

public class GetAll
    : RequestHandler<ChampionTypesRequest>, IRequestHandler<ChampionTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ChampionTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetChampionTypes()));

        return Results.Ok(response);
    }
}
