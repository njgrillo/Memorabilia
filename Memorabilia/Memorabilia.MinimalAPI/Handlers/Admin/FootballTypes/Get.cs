namespace Memorabilia.MinimalAPI.Handlers.Admin.FootballTypes;

public class Get
    : RequestHandler<FootballTypeRequest>, IRequestHandler<FootballTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(FootballTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetFootballType(request.Id))));
}
