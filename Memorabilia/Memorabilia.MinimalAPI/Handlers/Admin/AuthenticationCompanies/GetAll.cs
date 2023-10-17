namespace Memorabilia.MinimalAPI.Handlers.Admin.AuthenticationCompanies;

public class GetAll
    : RequestHandler<AuthenticationCompaniesRequest>, IRequestHandler<AuthenticationCompaniesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(AuthenticationCompaniesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetAuthenticationCompanies()));

        return Results.Ok(response);
    }
}
