namespace Memorabilia.MinimalAPI.Handlers.Admin.GameStyleTypes;

public class GetAll
    : RequestHandler<GameStyleTypesRequest>, IRequestHandler<GameStyleTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(GameStyleTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetGameStyleTypes()));

        return Results.Ok(response);
    }
}
