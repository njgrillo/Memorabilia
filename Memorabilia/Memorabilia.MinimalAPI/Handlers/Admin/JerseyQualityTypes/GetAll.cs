namespace Memorabilia.MinimalAPI.Handlers.Admin.JerseyQualityTypes;

public class GetAll
    : RequestHandler<JerseyQualityTypesRequest>, IRequestHandler<JerseyQualityTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(JerseyQualityTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetJerseyQualityTypes()));

        return Results.Ok(response);
    }
}
