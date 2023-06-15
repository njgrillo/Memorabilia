namespace Memorabilia.MinimalAPI.Handlers.Admin.Franchises;

public class GetAll
    : RequestHandler<FranchisesRequest>, IRequestHandler<FranchisesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(FranchisesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.Franchise[]>(await QueryRouter.Send(new GetFranchises()));

        return Results.Ok(response);
    }
}
