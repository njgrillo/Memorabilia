namespace Memorabilia.MinimalAPI.Handlers.Admin.AcquisitionTypes;

public class GetAll
    : Handler.RequestHandler<AcquisitionTypesRequest>, IRequestHandler<AcquisitionTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(AcquisitionTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetAcquisitionTypes()));

        return Results.Ok(response);
    }
}
