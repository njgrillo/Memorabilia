namespace Memorabilia.MinimalAPI.Handlers.Admin.AuthenticationCompanies;

public class Get
    : RequestHandler<AuthenticationCompanyRequest>, IRequestHandler<AuthenticationCompanyRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(AuthenticationCompanyRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetAuthenticationCompany(request.Id))));
}
