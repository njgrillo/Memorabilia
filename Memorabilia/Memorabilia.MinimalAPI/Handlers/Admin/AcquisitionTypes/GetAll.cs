namespace Memorabilia.MinimalAPI.Handlers.Admin.AcquisitionTypes;

public class GetAll
    : RequestHandler<AcquisitionTypesRequest>, IRequestHandler<AcquisitionTypesRequest, IResult>
{
    public GetAll(IMediator mediator) : base(mediator) { }

    public override async Task<IResult> Handle(AcquisitionTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await Mediator.Send(new GetAcquisitionTypes()));

        return Results.Ok(response);
    }
}
