namespace Memorabilia.MinimalAPI.Handlers.Admin.AcquisitionTypes;

public class Get
    : RequestHandler<AcquisitionTypeRequest>, IRequestHandler<AcquisitionTypeRequest, IResult>
{
    public Get(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(AcquisitionTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await Mediator.Send(new GetAcquisitionType(request.Id))));
}
