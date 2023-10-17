namespace Memorabilia.MinimalAPI.Handlers.Admin.PrivacyTypes;

public class GetAll
    : RequestHandler<PrivacyTypesRequest>, IRequestHandler<PrivacyTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(PrivacyTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetPrivacyTypes()));

        return Results.Ok(response);
    }
}
