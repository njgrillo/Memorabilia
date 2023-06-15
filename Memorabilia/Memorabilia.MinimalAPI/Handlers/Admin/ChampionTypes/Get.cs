namespace Memorabilia.MinimalAPI.Handlers.Admin.ChampionTypes;

public class Get
    : RequestHandler<ChampionTypeRequest>, IRequestHandler<ChampionTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ChampionTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetChampionType(request.Id))));
}
