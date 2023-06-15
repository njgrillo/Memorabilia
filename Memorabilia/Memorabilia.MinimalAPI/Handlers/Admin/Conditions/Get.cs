namespace Memorabilia.MinimalAPI.Handlers.Admin.Conditions;

public class Get
    : RequestHandler<ConditionRequest>, IRequestHandler<ConditionRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ConditionRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetCondition(request.Id))));
}
