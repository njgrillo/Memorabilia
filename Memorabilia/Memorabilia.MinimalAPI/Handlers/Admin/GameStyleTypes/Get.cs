namespace Memorabilia.MinimalAPI.Handlers.Admin.GameStyleTypes;

public class Get
    : RequestHandler<GameStyleTypeRequest>, IRequestHandler<GameStyleTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(GameStyleTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetGameStyleType(request.Id))));
}
