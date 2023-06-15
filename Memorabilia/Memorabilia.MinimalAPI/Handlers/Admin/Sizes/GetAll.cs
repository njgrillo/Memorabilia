namespace Memorabilia.MinimalAPI.Handlers.Admin.Sizes;

public class GetAll
    : RequestHandler<SizesRequest>, IRequestHandler<SizesRequest, IResult>
{
    public GetAll(QueryRouter queryRouter) : base(queryRouter) { }

    public override async Task<IResult> Handle(SizesRequest request,
                                               CancellationToken cancellationToken)
    {
        var response
            = new Response<Entity.DomainEntity[]>(await QueryRouter.Send(new GetSizes()));

        return Results.Ok(response);
    }
}
