namespace Memorabilia.MinimalAPI.Handlers.Admin.BammerTypes;

public class GetAll
    : RequestHandler<BammerTypesRequest>, IRequestHandler<BammerTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(BammerTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetBammerTypes()));

        return Results.Ok(response);
    }
}
