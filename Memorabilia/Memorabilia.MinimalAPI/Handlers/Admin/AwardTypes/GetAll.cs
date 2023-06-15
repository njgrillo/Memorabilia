namespace Memorabilia.MinimalAPI.Handlers.Admin.AwardTypes;

public class GetAll
    : RequestHandler<AwardTypesRequest>, IRequestHandler<AwardTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(AwardTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetAwardTypes()));

        return Results.Ok(response);
    }
}
