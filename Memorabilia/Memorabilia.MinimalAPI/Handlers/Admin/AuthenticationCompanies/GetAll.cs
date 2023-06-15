namespace Memorabilia.MinimalAPI.Handlers.Admin.AuthenticationCompanies;

public class GetAll
    : RequestHandler<AuthenticationCompaniesRequest>, IRequestHandler<AuthenticationCompaniesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(AuthenticationCompaniesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetAuthenticationCompanies()));

        return Results.Ok(response);
    }
}
