namespace Memorabilia.MinimalAPI.Handlers.Admin.LeaderTypes;

public class Get
    : RequestHandler<LeaderTypeRequest>, IRequestHandler<LeaderTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(LeaderTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetLeaderType(request.Id))));
}
