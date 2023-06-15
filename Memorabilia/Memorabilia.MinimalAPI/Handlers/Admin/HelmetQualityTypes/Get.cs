namespace Memorabilia.MinimalAPI.Handlers.Admin.HelmetQualityTypes;

public class Get
    : RequestHandler<HelmetQualityTypeRequest>, IRequestHandler<HelmetQualityTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(HelmetQualityTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetHelmetQualityType(request.Id))));
}
