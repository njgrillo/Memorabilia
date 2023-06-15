namespace Memorabilia.MinimalAPI.Handlers.Admin.PrivacyTypes;

public class GetAll
    : RequestHandler<PrivacyTypesRequest>, IRequestHandler<PrivacyTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(PrivacyTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetPrivacyTypes()));

        return Results.Ok(response);
    }
}
