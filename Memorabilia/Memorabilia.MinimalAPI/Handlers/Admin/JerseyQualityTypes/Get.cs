namespace Memorabilia.MinimalAPI.Handlers.Admin.JerseyQualityTypes;

public class Get
    : RequestHandler<JerseyQualityTypeRequest>, IRequestHandler<JerseyQualityTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(JerseyQualityTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetJerseyQualityType(request.Id))));
}