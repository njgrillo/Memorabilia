namespace Memorabilia.MinimalAPI.Handlers.Admin.PrivacyTypes;

public class Get
    : RequestHandler<PrivacyTypeRequest>, IRequestHandler<PrivacyTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(PrivacyTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetPrivacyType(request.Id))));
}
