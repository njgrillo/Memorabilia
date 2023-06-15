namespace Memorabilia.MinimalAPI.Handlers.Admin.Sizes;

public class Get
    : RequestHandler<SizeRequest>, IRequestHandler<SizeRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(SizeRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetSize(request.Id))));
}
