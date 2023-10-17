namespace Memorabilia.MinimalAPI.Handlers.Admin.HelmetQualityTypes;

public class Get
    : RequestHandler<HelmetQualityTypeRequest>, IRequestHandler<HelmetQualityTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(HelmetQualityTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetHelmetQualityType(request.Id))));
}
