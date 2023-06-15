namespace Memorabilia.MinimalAPI.Handlers.Admin.HelmetFinishes;

public class Get
    : RequestHandler<HelmetFinishRequest>, IRequestHandler<HelmetFinishRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(HelmetFinishRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.DomainEntity>(await QueryRouter.Send(new GetHelmetFinish(request.Id))));
}
