namespace Memorabilia.MinimalAPI.Handlers.Admin.LevelTypes;

public class GetAll
    : RequestHandler<LevelTypesRequest>, IRequestHandler<LevelTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(LevelTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetLevelTypes()));

        return Results.Ok(response);
    }
}
