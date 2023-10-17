namespace Memorabilia.MinimalAPI.Handlers.Admin.AuthenticationCompanies;

public class Get
    : RequestHandler<AuthenticationCompanyRequest>, IRequestHandler<AuthenticationCompanyRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(AuthenticationCompanyRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetAuthenticationCompany(request.Id))));
}
