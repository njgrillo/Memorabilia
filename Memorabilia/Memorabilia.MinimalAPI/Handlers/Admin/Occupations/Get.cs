namespace Memorabilia.MinimalAPI.Handlers.Admin.Occupations;

public class Get
    : RequestHandler<OccupationRequest>, IRequestHandler<OccupationRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(OccupationRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetOccupation(request.Id))));
}
