namespace Memorabilia.MinimalAPI.Handlers.Admin.AcquisitionTypes;

public class Get
    : RequestHandler<AcquisitionTypeRequest>, IRequestHandler<AcquisitionTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(AcquisitionTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetAcquisitionType(request.Id))));
}
