namespace Memorabilia.MinimalAPI.Handlers.Admin.PrivacyTypes;

public class Get
    : RequestHandler<PrivacyTypeRequest>, IRequestHandler<PrivacyTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(PrivacyTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetPrivacyType(request.Id))));
}
