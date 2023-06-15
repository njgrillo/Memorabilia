namespace Memorabilia.MinimalAPI.Handlers.Admin.Sports;

public class Get
    : RequestHandler<SportRequest>, IRequestHandler<SportRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(SportRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Sport>(await QueryRouter.Send(new GetSport(request.Id))));
}
