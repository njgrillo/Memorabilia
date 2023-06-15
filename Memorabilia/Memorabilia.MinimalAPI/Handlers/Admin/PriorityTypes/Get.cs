namespace Memorabilia.MinimalAPI.Handlers.Admin.PriorityTypes;

public class Get
    : RequestHandler<PriorityTypeRequest>, IRequestHandler<PriorityTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(PriorityTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetPriorityType(request.Id))));
}
