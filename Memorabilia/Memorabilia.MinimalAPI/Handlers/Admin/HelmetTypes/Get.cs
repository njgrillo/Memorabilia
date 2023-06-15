namespace Memorabilia.MinimalAPI.Handlers.Admin.HelmetTypes;

public class Get
    : RequestHandler<HelmetTypeRequest>, IRequestHandler<HelmetTypeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(HelmetTypeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetHelmetType(request.Id))));
}
