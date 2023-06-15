namespace Memorabilia.MinimalAPI.Handlers.Admin.Conditions;

public class GetAll
    : RequestHandler<ConditionsRequest>, IRequestHandler<ConditionsRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ConditionsRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetConditions()));

        return Results.Ok(response);
    }
}
