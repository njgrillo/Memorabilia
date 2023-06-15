namespace Memorabilia.MinimalAPI.Handlers.Admin.Colors;

public class Get
    : RequestHandler<ColorRequest>, IRequestHandler<ColorRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(ColorRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetColor(request.Id))));
}
