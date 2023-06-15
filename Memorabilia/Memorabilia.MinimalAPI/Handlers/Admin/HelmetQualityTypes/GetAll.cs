namespace Memorabilia.MinimalAPI.Handlers.Admin.HelmetQualityTypes;

public class GetAll
    : RequestHandler<HelmetQualityTypesRequest>, IRequestHandler<HelmetQualityTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(HelmetQualityTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetHelmetQualityTypes()));

        return Results.Ok(response);
    }
}
