namespace Memorabilia.MinimalAPI.Handlers.Admin.BaseballTypes;

public class Get
    : RequestHandler<BaseballTypeRequest>, IRequestHandler<BaseballTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(BaseballTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetBaseballType(request.Id))));
}
