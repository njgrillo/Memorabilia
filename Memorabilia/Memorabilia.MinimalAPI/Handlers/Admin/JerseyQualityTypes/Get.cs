namespace Memorabilia.MinimalAPI.Handlers.Admin.JerseyQualityTypes;

public class Get
    : RequestHandler<JerseyQualityTypeRequest>, IRequestHandler<JerseyQualityTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) {}

    public override async Task<IResult> Handle(JerseyQualityTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetJerseyQualityType(request.Id))));
}