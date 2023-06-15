namespace Memorabilia.MinimalAPI.Handlers.Admin.GloveTypes;

public class GetAll
    : RequestHandler<GloveTypesRequest>, IRequestHandler<GloveTypesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(GloveTypesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetGloveTypes()));

        return Results.Ok(response);
    }
}
