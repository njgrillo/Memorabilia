namespace Memorabilia.MinimalAPI.Handlers.Admin.LevelTypes;

public class Get
    : RequestHandler<LevelTypeRequest>, IRequestHandler<LevelTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(LevelTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetLevelType(request.Id))));
}
