namespace Memorabilia.MinimalAPI.Handlers.Admin.Franchises;

public class Get
    : RequestHandler<FranchiseRequest>, IRequestHandler<FranchiseRequest, IResult>
{
    public Get(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(FranchiseRequest request,
                                               CancellationToken cancellationToken)
        => Results.Ok(new Response<Entity.Franchise>(await QueryRouter.Send(new GetFranchise(request.Id))));
}
