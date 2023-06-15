namespace Memorabilia.MinimalAPI.Handlers.Admin.GloveTypes;

public class Get
    : RequestHandler<GloveTypeRequest>, IRequestHandler<GloveTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(GloveTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetGloveType(request.Id))));
}
